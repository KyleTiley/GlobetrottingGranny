using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionDeletion : MonoBehaviour
{
    //Deletes sections once they are out of view of the player
    public GameObject sectionDeletionPoint;

    private void Start()
    {
        sectionDeletionPoint = GameObject.Find("SectionDeletionPoint");
    }

    private void Update() 
    {
        if(transform.position.z < sectionDeletionPoint.transform.position.z)
        {
            Destroy(this.gameObject);
        }
    }
}
