using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pickups/Pickup3")]
public class Pickup3 : PickupEffect
{
    float pickupDuration = 10f;

    public override void Apply(GameObject target){
        PlayerMovement.slowTimer = pickupDuration;
    }
}
