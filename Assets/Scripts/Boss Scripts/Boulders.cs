using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulders : MonoBehaviour
{
    public GameObject Boulder;
    bool leftMove;
    bool rightMove;
    int directionPicker;
    float directionTimer = 0;

    private void Awake(){
        Boulder = this.gameObject;
        directionPicker = Random.Range(0,2);
    }

    private void FixedUpdate(){
            directionTimer += Time.deltaTime;
            if(directionTimer > 2){
                if(directionPicker==0){
                    directionPicker = 1;
                }
                else if(directionPicker == 1){
                    directionPicker = 0;
                }
                directionTimer = 0;
            }
        }

    private void Update() {
        if(directionPicker == 0){
            Boulder.transform.Rotate(0, 0, 2, Space.World);
            Boulder.transform.Translate(Vector3.left * 5 * Time.deltaTime, Space.World);
        }
        else if(directionPicker == 1){
            Boulder.transform.Rotate(0, 0, -2, Space.World);
            Boulder.transform.Translate(Vector3.right * 5 * Time.deltaTime, Space.World);
        }
    }
}
