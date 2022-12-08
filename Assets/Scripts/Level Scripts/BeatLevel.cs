using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatLevel : MonoBehaviour
{
    public static void LevelEnder(){
        EventManagerScript.current.StartLevelsBeatenEvent();
    }
}
