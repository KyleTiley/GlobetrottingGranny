using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public static void EventStarter(){
        EventManagerScript.current.StartBossEvent();
    }
}
