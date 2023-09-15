using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    public Rigidbody2D rb;
    public float force;
    PlayerController play;
    Health health;
    public int type;
    Boss2 boss;
    private void Start()
    {
        play = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        health = GameObject.FindGameObjectWithTag("Health").GetComponent<Health>();
        boss=GetComponent<Boss2>();
        rb =GetComponent<Rigidbody2D>();
        
        {
            rb.velocity = transform.up * force;
        }
        if(GameObject.Find("Bullet2")) Destroy(gameObject, 1.5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            play.curr -= 5;
            health.SetHealth(play.curr);
            Destroy(gameObject);
        }
        if(collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
