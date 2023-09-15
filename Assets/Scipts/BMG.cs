using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMG : MonoBehaviour
{
    public void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
