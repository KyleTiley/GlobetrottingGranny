using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EventManagerScript : MonoBehaviour
{
    //SINGLETON PATTERN USED
    public static EventManagerScript current;

    //ALL 8 EVENTS
    public event Action passingObstacleEvent;
    public event Action pickupCollectedEvent;   //Works for all 3 pickups
    public event Action spawningBossEvent; //Works for both bosses
    public event Action levelsBeatenEvent;  //Works for both levels

    //Singleton pattern implemented, events do not need to be static
    private void Awake() {
        if(current == null){
            current = this;
        }
        else{
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    //Used when passing obstacles
    public void StartPassingObstacleEvent(){
        passingObstacleEvent?.Invoke();
    }

    //Used for all 3 pickups
    public void StartPickupEvent(){
        pickupCollectedEvent?.Invoke();
    }

    //Used to spawn both bosses
    public void StartBossEvent(){
        spawningBossEvent?.Invoke();
    }

    //Used when a boss is beaten
    public void StartLevelsBeatenEvent(){
        levelsBeatenEvent?.Invoke();
    }
}
