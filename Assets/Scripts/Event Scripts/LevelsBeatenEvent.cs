using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsBeatenEvent : MonoBehaviour
{
    //VARIABLES
    private bool levelBeaten = false;

    private void Start(){
        EventManagerScript.current.levelsBeatenEvent += LevelBeater;
    }

    private void Update() {
        if(levelBeaten){
            //display levels beaten with this
            levelBeaten = false;
        }
    }

    private void LevelBeater(){
        levelBeaten = true;
    }

    private void OnDisable(){
        EventManagerScript.current.levelsBeatenEvent -= LevelBeater;
    }
}
