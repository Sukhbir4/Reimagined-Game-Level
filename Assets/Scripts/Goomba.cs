using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : MonoBehaviour
{
    [SerializeField] float speed;
    Transform trans;
    Rigidbody2D body;
   
    bool turn;
    bool hitFace;


    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }


   


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.collider.gameObject.tag !=("Player") && collision.collider.gameObject.tag == "Ground")
        {
            hitFace = true;
        }

        if (hitFace)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            hitFace = false;
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }


        if(collision.collider.tag == "DeathFloor")
        {
            Destroy(gameObject);
        }
       


    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
