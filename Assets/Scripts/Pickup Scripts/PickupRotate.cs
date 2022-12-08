using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRotate : MonoBehaviour
{
    public GameObject pickup;

    private void Awake() {
        pickup = this.gameObject;
    }

    private void Update(){
        pickup.transform.Rotate(0, 1, 0, Space.World);
    }
}
