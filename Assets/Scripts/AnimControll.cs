using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControll : MonoBehaviour
{
    Animator anim;
    Player_Controller playerMovement;   



    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<Player_Controller>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.GetIsWalking())
        {
            anim.SetBool("Walking",true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }

        if (playerMovement.GetIsRunning())
        {
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }
        if (playerMovement.GetIsGrounded())
        {
            anim.SetBool("InAir", false);
        }
        else
        {
            anim.SetBool("InAir", true);
        }
    }
}
