using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pickups/Pickup1")]
public class Pickup1 : PickupEffect
{
    public int pointAmount = 5;

    public override void Apply(GameObject target){
        PassingObstacleEvent.totalScore += 5;
    }
}
