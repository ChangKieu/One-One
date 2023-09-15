using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public AudioSource gun;
    public GameObject bullet;
    public Transform shotPoint;
    public float startTime;
    public float timeBtw;
    private void Update()
    {
        Vector3 dis = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(dis.y, dis.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ );
        if (rotZ < -90 || rotZ > 90 ) Flip();
        if (Input.GetMouseButtonDown(0))
        {
            gun.Play();
           Instantiate(bullet, shotPoint.position, transform.rotation);
        }

    }
    void Flip()
    {
        transform.Rotate(180f,0f,0f);
    }
}
