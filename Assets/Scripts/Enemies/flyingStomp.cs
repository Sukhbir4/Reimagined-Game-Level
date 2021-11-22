using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingStomp : MonoBehaviour
{

    [SerializeField] int bounce;
    BoxCollider2D enemy;
    Rigidbody2D enBody;


    // Start is called before the first frame update
    void Start()
    {
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
   
            Rigidbody2D player = collision.GetComponent<Rigidbody2D>();
            player.AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            enBody.gravityScale = 2;
        }
    }
}
