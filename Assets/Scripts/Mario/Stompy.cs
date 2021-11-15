using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stompy : MonoBehaviour
{
    [SerializeField] float bounceBack;
    

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


                    

            Destroy(transform.parent.gameObject);
        }

       
       

    }
}
