using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    Transform trans;
    Rigidbody2D body;
    [SerializeField] float runSpeed;
    [SerializeField] float defaultSpeed; 
    [SerializeField] float jumpForce;
    [SerializeField] ParticleSystem runSmoke;
    [SerializeField] int enemieBounceBack;

    [SerializeField] bool hasStarPower;

    Stompy stomp;

    float speed;

    bool jumpInput;
    bool isGrounded;
    bool isRunning;
    bool isWalking;

    // Start is called before the first frame update
    void Start()
    {
        speed = defaultSpeed;
        trans = GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();
        stomp = GetComponent<Stompy>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.W))
        {
            jumpInput = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            jumpInput = false;
        }
    }
    

    void FixedUpdate()
    {
        if (jumpInput == true && isGrounded)
        { 
            jump();
        }
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            speed = runSpeed;
            trans.position += transform.right * Time.deltaTime * speed;
            trans.rotation = Quaternion.Euler(0, 0, 0);
            isRunning = true;
            runSmoke.gameObject.SetActive(true);
        }
        else if (Input.GetKey(KeyCode.D)) // also getkey down and up but they are called once while get key is called every frame
        {
            speed = defaultSpeed;
            trans.position += transform.right * Time.deltaTime * speed;
            trans.rotation = Quaternion.Euler(0, 0, 0);
            isWalking = true;
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift) && isGrounded) // also getkey down and up but they are called once while get key is called every frame
        {
            speed = runSpeed; 
            trans.position += transform.right * Time.deltaTime * speed;
            trans.rotation = Quaternion.Euler(0, 180, 0);
            isRunning = true;
            runSmoke.gameObject.SetActive(true);
        }
        else if (Input.GetKey(KeyCode.A)) // also getkey down and up but they are called once while get key is called every frame
        {
            speed = defaultSpeed;
            trans.position += transform.right * Time.deltaTime * speed;
            trans.rotation = Quaternion.Euler(0, 180, 0);
            isWalking = true;
        }

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            isWalking = false;
        }
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = false;
            runSmoke.gameObject.SetActive(false);
        }
    }

    void jump()
    {

        body.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
        runSmoke.gameObject.SetActive(false);
    }
  

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Ground")
        {
            for(int i = 0; i < collision.contacts.Length; i++) // loops through all the collisions floors and walls
            {
                if (collision.contacts[i].normal.y > 0.5) //checks that the collision is the floor not the wall
                {
                    isGrounded = true;
                }
            }
        }

        //if (collision.gameObject.tag == "Stompy")
        //{
        //    Debug.Log("stompy");
        //    body.AddForce(transform.up * enemieBounceBack, ForceMode2D.Impulse);
            
        //}

    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Stompy")
    //    {
    //        Debug.Log("stompy");
    //        body.AddForce(transform.up * enemieBounceBack, ForceMode2D.Impulse);
    //    }
    //}

    public float GetSpeed()
    {
        return speed;
    }

    public bool GetIsWalking()
    {
        return isWalking;
    }

    public bool GetIsRunning()
    {
        return isRunning;
    }

    public bool GetIsGrounded()
    {
        return isGrounded;


    }




}
