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
    [SerializeField] float dashForce;

    [SerializeField] bool hasStarPower;

    [SerializeField] int enemyBounceBack;

    [SerializeField] ParticleSystem runSmoke;

    Vector2 temp;

    Stompy stomp;

    float speed;

    bool jumpInput;
    bool isGrounded;
    bool isRunning;
    bool isWalking;
    bool canDash;
    bool dashInput;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            dashInput = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            dashInput = false;
        }

        Debug.Log(canDash);
    }
    

    void FixedUpdate()
    {
        if (jumpInput == true && isGrounded)
        { 
            jump();
        }

        if(dashInput == true && canDash)
        {
            dash();
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
        else if (Input.GetKey(KeyCode.D))
        {
            speed = defaultSpeed;
            trans.position += transform.right * Time.deltaTime * speed;
            trans.rotation = Quaternion.Euler(0, 0, 0);
            isWalking = true;
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift) && isGrounded) 
        {
            speed = runSpeed; 
            trans.position += transform.right * Time.deltaTime * speed;
            trans.rotation = Quaternion.Euler(0, 180, 0);
            isRunning = true;
            runSmoke.gameObject.SetActive(true);
        }
        else if (Input.GetKey(KeyCode.A)) 
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

    void dash()
    {
        body.AddForce(transform.right * dashForce, ForceMode2D.Impulse);
        canDash = false;
        //speed = dashForce;
    }

    void jump()
    {

        body.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
        runSmoke.gameObject.SetActive(false);
    }
  

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Ground" || collision.collider.gameObject.tag == "MushroomBlock" || collision.collider.gameObject.tag == "MafiaBlock")
        {
            for(int i = 0; i < collision.contacts.Length; i++) 
            {
                if (collision.contacts[i].normal.y > 0.5) 
                {
                    isGrounded = true;
                    canDash = true;
                }
            }
        }


        //if (collision.gameObject.tag == "Stompy")
        //{
        //    Debug.Log("stompy");
        //    body.AddForce(transform.up * enemieBounceBack, ForceMode2D.Impulse);
            
        //}

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MushroomBlock" || collision.gameObject.tag == "MafiaBlock")
        {
            collision.gameObject.GetComponent<QuestionBlock>().QuestionBlockBounce();
        }

        //Scale up Mario with Mushroom powerup
        if (collision.gameObject.tag == "Mushroom")
        {
            temp = transform.localScale;

            temp.x += 0.2f;
            temp.y += 0.75f;

            transform.localScale = temp;
        }

        if (collision.gameObject.tag == "Mafia")
        {
            Debug.Log("Mafia");
        }
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
