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

    [SerializeField] int bounce;
    [SerializeField] ParticleSystem blood;

    Animator anim;
    BoxCollider2D enemy;
    Rigidbody2D enBody;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
        enemy = transform.GetComponent<BoxCollider2D>();
        enBody = transform.GetComponent<Rigidbody2D>();
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Test
        if (collision.tag == "Player")
        {
            anim.SetBool("die", true);

            Rigidbody2D player = collision.GetComponent<Rigidbody2D>();

            player.AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            blood.gameObject.SetActive(true);
            enemy.enabled = false;
            enBody.gravityScale = 1;
        }

        //Check bullet collision
        if (collision.tag == "Player Bullet")
        {
            anim.SetBool("die", true);

            blood.gameObject.SetActive(true);
            enemy.enabled = false;
            enBody.gravityScale = 1;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
