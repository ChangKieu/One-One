using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Renderer render;
    float speed = 5f;
    bool isRight = true;
    public GameObject[] curr;
    int nextPoint = 0;
    GameObject next;
    int hp = 5;
    PlayerController play;
    Health health;
    private void Start()
    {
        play = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        health = GameObject.FindGameObjectWithTag("Health").GetComponent<Health>();
        next = curr[0];
        render=GetComponent<Renderer>();
    }
    private void Update()
    {
        Moving();
        if (hp < 0) Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            hp--;
            render.material.color= Color.red;
            Invoke("ChangeColor",0.5f); 
        }
        if (collision.CompareTag("Player"))
        {
            play.curr -= 10;
            health.SetHealth(play.curr);
            render.material.color = Color.black;
            Invoke("ChangeColor", 0.5f);
        }
    }
    private void ChangeColor()
    {
        render.material.color = Color.white;
    }
    
    void Moving()
    {
        if(transform.position==next.transform.position)
        {
            nextPoint++;
            if(nextPoint>=curr.Length)
            {
                nextPoint= 0;
            }
            next = curr[nextPoint];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, next.transform.position, speed*Time.deltaTime);
        }
        if(isRight && transform.position.x < next.transform.position.x)
        {
            Flip();
            isRight= false;
        }
        else if (isRight == false && transform.position.x > next.transform.position.x)
        {
            Flip();
            isRight= true;
        }
    }
    void Flip()
    {

        transform.Rotate(0f, 180f, 0f);
    }
}
