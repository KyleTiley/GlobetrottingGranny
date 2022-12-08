using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PassingObstacleEvent : MonoBehaviour
{
    //VARIABLES
    private bool passed = false;
    public static int totalScore = 0;
    public static int finalScore = 0;
    private TextMeshProUGUI scoreDisplay;

    private void Start() {
        EventManagerScript.current.passingObstacleEvent += isPassed;
        scoreDisplay = GameObject.FindObjectOfType<TextMeshProUGUI>();
    }

    private void Update() {
        if(passed){
            totalScore++;
            finalScore = totalScore;
            passed = false;
        }
        scoreDisplay.text = "Score: " + totalScore.ToString();
    }

    private void isPassed(){
        passed = true;
    }

    private void OnDisable() {
        EventManagerScript.current.passingObstacleEvent -= isPassed;
    }
}
