using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/ExtraLife")]
public class Powerup_ExtraLife : PowerupEffect
{
    float powerupDuration = 20f;

    public override void Apply(GameObject target)
    {
        target.GetComponent<DeathCollision>().immuneTimer = powerupDuration;
    }
}
