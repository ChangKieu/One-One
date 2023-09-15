using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{
    public int openDirection;
    /*
        1 -> need bottom;
        2-> need top;
        3 -> need right;
        4 -> need left;
     */
    private RomeTemplates templates;
    private int random;
    private bool spawned = false;
    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Room").GetComponent<RomeTemplates>();
        Invoke("Spawn", 0.1f);
    }
    void Spawn()
    {
        if (spawned == false)
        {
            if (openDirection == 2)
            {
                random = Random.Range(0, templates.toprooms.Length);
                Instantiate(templates.toprooms[random], transform.position, templates.toprooms[random].transform.rotation);
            }
            else if (openDirection == 1)
            {
                random = Random.Range(0, templates.bottomrooms.Length);
                Instantiate(templates.bottomrooms[random], transform.position, templates.bottomrooms[random].transform.rotation);
            }
            else if (openDirection == 4)
            {
                random = Random.Range(0, templates.leftrooms.Length);
                Instantiate(templates.leftrooms[random], transform.position, templates.leftrooms[random].transform.rotation);
            }
            else if (openDirection == 3)
            {
                random = Random.Range(0, templates.rightrooms.Length);
                Instantiate(templates.rightrooms[random], transform.position, templates.rightrooms[random].transform.rotation);
            }
            random = Random.Range(0, templates.type.Length);
            Instantiate(templates.type[random], transform.position, templates.type[random].transform.rotation);
            spawned = true;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        templates = GameObject.FindGameObjectWithTag("Room").GetComponent<RomeTemplates>();
        if (collision.CompareTag("SpawnPoint") )
        {
            if(collision.GetComponent<SpawnRoom>().spawned==false && spawned==false)
            {
                    Instantiate(templates.closeroom, transform.position, Quaternion.identity);
                    Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
