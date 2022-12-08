using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowTimer : MonoBehaviour
{
    // public Image uiFill;
    // public GameObject UIThingy;
    
    // public int durationFill;
    // private int remainingDuration;
    // public static bool reEnable = false;
    // public bool started = false;

    // private void Update() 
    // {
    //     if(reEnable)
    //     {
    //         UIThingy.SetActive(true);
    //         if(!started)
    //         {
    //             Being(durationFill);
    //             started = true;
    //         }
    //     }
    // }
    
    // //cant seem to get this all to work :(
    // private void Being(int Second)
    // {
    //     remainingDuration = Second;
    //     StartCoroutine(UpdateTimer());
    // }

    // private IEnumerator UpdateTimer()
    // {
    //     while(remainingDuration >= 0)
    //     {
    //         uiFill.fillAmount = Mathf.InverseLerp(0, durationFill, remainingDuration);
    //         remainingDuration--;
    //         yield return new WaitForSeconds(1f);
    //     }
    // }

    // private void OnEnd()
    // {
    //     UIThingy.SetActive(false);
    // }
}
