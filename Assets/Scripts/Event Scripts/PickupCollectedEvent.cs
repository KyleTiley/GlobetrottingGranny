using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCollectedEvent : MonoBehaviour
{
    public PickupEffect pickupEffect;
    private bool collected = false;

    private void Start(){
        EventManagerScript.current.pickupCollectedEvent += isCollected;
    }

    private void Update(){
        if(collected){
            Destroy(gameObject);
            pickupEffect.Apply(gameObject);
            collected = false;
        }
    }

    private void isCollected(){
        collected = true;
    }

    private void OnDisable(){
        EventManagerScript.current.pickupCollectedEvent -= isCollected;
    }
}
