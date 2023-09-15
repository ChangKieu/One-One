using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    RomeTemplates templates;
    private void Start()
    {
        templates=GameObject.FindGameObjectWithTag("Room").GetComponent<RomeTemplates>();
        templates.rooms.Add(this.gameObject);
    }
}
