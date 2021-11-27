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
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.collider.tag == "DeathFloor")
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }

    
}
