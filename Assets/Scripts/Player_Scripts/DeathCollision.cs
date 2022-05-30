using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCollision : MonoBehaviour
{
    //EXTRA LIFE VARIABLES
    public bool isImmune = false;
    public float immuneTimer = 0f;
    
    private void Update()
    {
        immuneTimer -= Time.deltaTime;
        if(immuneTimer > 0)
        {
            isImmune = true;
        }
        else
        {
            isImmune = false;
        }
    }

    //Ends the game if the player collides with an obstacle
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Obstacle")
        {
            if(isImmune)
            {
                //make it known, maybe destroy the obstacle with particle effects
                Destroy(collider.gameObject);
                immuneTimer = 0;
            }
            else
            {
                //SceneManager.LoadScene(1);
                Debug.Log("fdsf");
            }
        }
        
    }
}
