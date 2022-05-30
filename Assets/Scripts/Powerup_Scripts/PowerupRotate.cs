using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupRotate : MonoBehaviour
{
    public GameObject Powerup;


    private void Awake() 
    {
        Powerup = this.gameObject;
    }

    private void Update()
    {
        Powerup.transform.Rotate(0, 1, 0, Space.World);
    }
}
