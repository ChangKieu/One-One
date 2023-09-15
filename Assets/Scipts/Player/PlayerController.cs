using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Renderer render;
    public Rigidbody2D rb;
    public Animator animator;
    public float speed = 10f;
    public float x, y;
    bool isright = true;
    public int hp=100;
    public int curr;
    public Health health;
    public bool win=false;
    public GameObject winPanel,losePanel;
    private void Start()
    {
        curr = hp;
        health.SetMaxHealth(curr);
        render=GetComponent<Renderer>();
    }
    private void Awake()
    {
        transform.position = Vector3.zero; 
        transform.rotation=Quaternion.identity;
    }
    private void Update()
    {
        if (win)
        {
            winPanel.SetActive(true);
        } 
        if(curr<=0)
        {
            losePanel.SetActive(true);
        }
        //Dichuyen
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(speed * x, speed * y);
        if (isright && x < 0)
        {
            Flip();
            isright = false;
        }
        if (isright == false && x > 0)
        {
            Flip();
            isright = true;
        }
        if (x != 0 || y != 0)
        {
            animator.SetBool("Go", true);

        }
        else animator.SetBool("Go", false);

    }
    private void Flip()
    {
        transform.Rotate (0f,180f,0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet2") || collision.CompareTag("Boss"))
        {
            render.material.color = Color.red;
            Invoke("ChangeColor", 0.2f);
        }
        if(collision.CompareTag("Exit"))
        {
            Invoke("isWin", 2f);
        }
    }
    private void ChangeColor()
    {
        render.material.color = Color.white;
    }
    private void isWin()
    {
        win = true;
    }
}
