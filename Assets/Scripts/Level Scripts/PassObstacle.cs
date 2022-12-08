using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassObstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision) {
        EventManagerScript.current.StartPassingObstacleEvent();
    }
}
