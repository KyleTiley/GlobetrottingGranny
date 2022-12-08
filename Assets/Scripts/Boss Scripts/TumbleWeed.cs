using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumbleWeed : MonoBehaviour
{
    public GameObject Tumbler;

    private void Awake(){
        Tumbler = this.gameObject;
    }

    private void Update(){
        Tumbler.transform.Rotate(-2, 0, 0, Space.World);
        Tumbler.transform.Translate(Vector3.back * 5 * Time.deltaTime, Space.World);
    }
}
