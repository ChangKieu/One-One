using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    Transform target;
    Vector3 velocity = Vector3.zero;
    [Range(0, 1)]
    public float smoothTime;
    public Vector3 pos;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        target.transform.position = Vector3.zero;
    }
    private void LateUpdate()
    {
        Vector3 targetPos = new Vector3 (target.position.x,target.position.y,-10f);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }

}
