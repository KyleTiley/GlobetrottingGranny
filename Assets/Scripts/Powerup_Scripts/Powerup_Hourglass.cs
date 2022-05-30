using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Hourglass")]
public class Powerup_Hourglass : PowerupEffect
{
    float powerupDuration = 10f;

    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerMovement>().slowTimer = powerupDuration;
    }
}
