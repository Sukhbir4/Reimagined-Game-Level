using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    [SerializeField] int speed;
    int num;


    private void Start()
    {
         Mathf.Clamp01(num);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(waypoints[num].transform.position, transform.position) == 0)
        {
            num++;
            if(num >= waypoints.Length)
            {
                num = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[num].transform.position, Time.deltaTime * speed);
    }
}
