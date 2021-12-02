using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{

    [SerializeField] Text TextVar;
    [SerializeField] int TimeRemaining;
    [SerializeField] GameObject mario;
    [SerializeField] GameObject deathscreen;
    
    // Update is called once per frame
    void Update()
    {
        TextVar.text = $"Time: {TimeRemaining - Time.realtimeSinceStartup:0}";

        if(TimeRemaining < 0.1)
        {
            //Debug.Log("You've run out of time");
            ////mario = gameObject.GetComponent<mario>();
            ////deathScreen.SetActive(true);
        }


    }
}
