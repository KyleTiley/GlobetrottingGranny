using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision) {
        EventManagerScript.current.StartPickupEvent();
    }
}
