using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stompy : MonoBehaviour
{
   
    

    Goomba goomba;
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //anim.SetBool("IsStomp", true);
            // Destroy(transform.parent.gameObject);
            Rigidbody2D player = collision.GetComponent<Rigidbody2D>();
            player.AddForce(Vector2.up * 10);
            Debug.Log("hit player");
        }
        Debug.Log("hit");

        

    }

   

}
