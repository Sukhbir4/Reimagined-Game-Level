using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingKoopa : MonoBehaviour
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

        if (collision.collider.tag == "DeathFloor")
        {
            Die();
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

        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
