using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathScreenScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI deathScoreDisplay;

    private void Start()
    {
        deathScoreDisplay = GameObject.FindObjectOfType<TextMeshProUGUI>();
    }

    private void Update()
    {
        deathScoreDisplay.text = "Score: " + PassingObstacleEvent.finalScore.ToString();
    }
}
