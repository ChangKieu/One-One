using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public int openDirection;
    /*
        1 -> top;
        2-> bottom;
        3 -> left;
        4 -> right;
     */
    RomeTemplates templates;
    private int random;
    private bool spawned = false;
    private void Start()
    {
        templates=GameObject.FindGameObjectWithTag("Room").GetComponent<RomeTemplates>();
        Invoke("Spawn", 1f);
    }
    void Spawn()
    {
        if(spawned==false)
        {
            if (openDirection == 1)
            {
                random = Random.Range(0, templates.toprooms.Length);
                Instantiate(templates.toprooms[random], transform.position, templates.toprooms[random].transform.rotation);
            }
            else if (openDirection == 2)
            {
                random = Random.Range(0, templates.bottomrooms.Length);
                Instantiate(templates.bottomrooms[random], transform.position, templates.bottomrooms[random].transform.rotation);
            }
            else if (openDirection == 3)
            {
                random = Random.Range(0, templates.leftrooms.Length);
                Instantiate(templates.leftrooms[random], transform.position, templates.leftrooms[random].transform.rotation);
            }
            else if (openDirection == 4)
            {
                random = Random.Range(0, templates.rightrooms.Length);
                Instantiate(templates.rightrooms[random], transform.position, templates.rightrooms[random].transform.rotation);
            }
            spawned= true;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnPoint") && collision.GetComponent<Point>().spawned == true)
        {
            Destroy(gameObject);
        }
    }
}
