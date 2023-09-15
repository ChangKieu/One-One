using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    float vec;
    Renderer render;
    public Sprite[] sprites;
    int index;
    public float timeSpawn=0;
    [SerializeField] float timeBtw;
    public GameObject bullet;
    public Transform point;
    int hp;
    private void Start()
    {
        hp = Random.Range(5, 10);
        vec = Random.Range(20f, 40f);
        index = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[index];
        render= GetComponent<Renderer>();
    }
    private void Update()
    {
        if(hp<0)
        {
            Destroy(gameObject);
        }
        timeBtw = Random.Range(0.2f, 1.5f);
        transform.Rotate(0f, 0f, Time.deltaTime * vec);
        if(timeSpawn <= 0)
        {
            Instantiate(bullet, point.position, transform.rotation);
            timeSpawn = timeBtw;
        }
        else
        {
            timeSpawn-= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            hp--;
            render.material.color = Color.red;
            Invoke("ChangeColor", 0.2f);
        }
    }
    private void ChangeColor()
    {
        render.material.color = Color.white;
    }
}
