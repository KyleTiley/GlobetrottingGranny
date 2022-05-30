using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public PowerupEffect powerupEffect;

    private void OnTriggerEnter(Collider collision)
    {
        Destroy(gameObject);
        powerupEffect.Apply(collision.gameObject);
    }
}
