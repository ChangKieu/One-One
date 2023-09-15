using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RomeTemplates : MonoBehaviour
{
    public GameObject[] toprooms;
    public GameObject[] bottomrooms;
    public GameObject[] leftrooms;
    public GameObject[] rightrooms;
    public GameObject[] type;
    public GameObject closeroom;
    public GameObject exit;
    public List<GameObject> rooms;
    public float waitTime = 3f;
    bool check=false;
    public float max;
    private void Start()
    {
        
    }
    private void Update()
    {
        if(waitTime<=0 && check==false)
        {
            Instantiate(exit, rooms[rooms.Count - 1].transform.position, Quaternion.identity);
            check= true;
        }
        else waitTime-= Time.deltaTime;
        
    }
}
