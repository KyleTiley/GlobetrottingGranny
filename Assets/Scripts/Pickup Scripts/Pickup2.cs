using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pickups/Pickup2")]
public class Pickup2 : PickupEffect
{
    float pickupDuration = 20f;

    public override void Apply(GameObject target){
        DeathCollision.immuneTimer = pickupDuration;
    }
}
