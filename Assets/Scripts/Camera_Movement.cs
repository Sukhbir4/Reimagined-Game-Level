using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    [SerializeField] GameObject playerObj; 
    Transform trans;
    Player_Controller player;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        player = playerObj.GetComponent<Player_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        // trans.position = new Vector3(playerObj.transform.position.x, trans.position.y,trans.position.z);

        if (playerObj.transform.position.x - trans.position.x > 3)
        {
            trans.position += transform.right * Time.deltaTime * player.GetSpeed();
        }
        if (playerObj.transform.position.x - trans.position.x < -3)
        {
            trans.position -= transform.right * Time.deltaTime * player.GetSpeed(); // checks if player is 3 units ahead or behind the cam and then moves it at the same speed  
        }

    }
}
