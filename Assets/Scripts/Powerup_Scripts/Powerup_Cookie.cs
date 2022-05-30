using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Cookie")]
public class Powerup_Cookie : PowerupEffect
{
    public int pointAmount = 5;

    public override void Apply(GameObject target)
    {
        target.GetComponent<ScoreCounter>().scoreNumber += pointAmount;
    }
}
