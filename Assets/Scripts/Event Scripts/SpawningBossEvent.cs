using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningBossEvent : MonoBehaviour
{
    //VARIABLES
    private bool bossSpawned = false;

    private void Start(){
        EventManagerScript.current.spawningBossEvent += BossSpawner;
    }

    private void Update() {
        if(bossSpawned){
            LevelCreation.spawnBoss = true;
            bossSpawned = false;
        }
    }

    private void BossSpawner(){
        Debug.Log("TESTER");
        bossSpawned = true;
    }

    private void OnDisable(){
        EventManagerScript.current.spawningBossEvent -= BossSpawner;
    }
}
