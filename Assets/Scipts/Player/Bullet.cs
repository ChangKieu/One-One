using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    private void Start()
    {
        Destroy(gameObject, 1f);
        rb.velocity=transform.right*speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Boss") || collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
