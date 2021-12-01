using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingKoopa : MonoBehaviour
{
    [SerializeField] float speed;
    Transform trans;
    Rigidbody2D body;
    [SerializeField] GameObject RegularKoopa;
    [SerializeField] Transform koopaPosition;
    
    
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
        if (collision.collider.tag == "DeathFloor")
        {
            Die();
        }

        if (collision.collider.tag == "Ground")
        {
            var Koopa = Instantiate(RegularKoopa, koopaPosition.position, Quaternion.Euler(new Vector3(0,0,0)));
            Destroy(gameObject);
        }

       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponent<Renderer>())
        {
            if (collision.tag == "waypoint" || collision.tag == "Player")
            {
                hitFace = !hitFace;
                Debug.Log("pine");
            }

            if (hitFace)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            if (collision.tag == "Player Bullet")
            {
                Rigidbody2D player = collision.GetComponent<Rigidbody2D>();
                body.gravityScale = 2;
                Debug.Log("grav scale " + body.gravityScale);
                body.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
            }
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void spawnKoopa()
    {



    }
}
