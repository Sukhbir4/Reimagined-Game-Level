using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stompy : MonoBehaviour
{


    [SerializeField] int bounce;
    [SerializeField] ParticleSystem blood;
    Goomba goomba;
    Animator anim;
    BoxCollider2D enemy;
    Rigidbody2D enBody;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>();
        enemy = transform.parent.GetComponent<BoxCollider2D>();
        enBody = transform.parent.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetBool("die", true);
            Rigidbody2D player = collision.GetComponent<Rigidbody2D>();
            player.AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            blood.gameObject.SetActive(true);
            enemy.enabled = false;
            Debug.Log(enemy.name);
            Debug.Log("hey");
            enBody.gravityScale = 1;
            


        }
    }      
}