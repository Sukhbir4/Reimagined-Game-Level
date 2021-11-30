using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    [SerializeField] Text TextVar;
    [SerializeField] int startTime;

    // Update is called once per frame
    void Update()
    {
        TextVar.text = $"Time: {startTime - Time.realtimeSinceStartup:0}";
    }
}
