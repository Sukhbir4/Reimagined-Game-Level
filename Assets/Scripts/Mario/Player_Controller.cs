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

    //Powerup Variables
    SpriteRenderer rend;
    [SerializeField] Sprite mario, mafia;

    bool mafiaPowerup = false;

    //Bullet Variables
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] float bulletSpeed;
    [SerializeField] float shootDelay;
    float timeToNextShot = 0;

    Vector2 temp;
    PlayerHealth hp;

    Stompy stomp;

    float speed;

    bool jumpInput;
    bool isGrounded;
    bool isRunning;
    bool isWalking;
    bool canDash;
    bool dashInput;
    bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        speed = defaultSpeed;

        trans = GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();

        stomp = GetComponent<Stompy>();

        hp = GetComponent<PlayerHealth>();

        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
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
        }

        if (Input.GetKey(KeyCode.E) && CanShoot())
        {
            ShootBullet();
        }

        if (hp.GetHp() <= 0 )
        {
            canMove = false;
        }
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

    void ShootBullet()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0)));

        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;

        Destroy(bullet, 5);
    }

    bool CanShoot()
    {
        if (mafiaPowerup)
        {
            if (timeToNextShot < Time.realtimeSinceStartup)
            {
                timeToNextShot = Time.realtimeSinceStartup + shootDelay;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
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
            Destroy(collision.gameObject);

            gameObject.GetComponent<PlayerHealth>().SetHp(1);

            /*temp = transform.localScale;

            temp.x += 0.2f;
            temp.y += 0.75f;

            transform.localScale = temp;*/

            Debug.Log("Get big");
        }

        if (collision.gameObject.tag == "Mafia")
        {
            Destroy(collision.gameObject);
            Debug.Log("Mafia");
            mafiaPowerup = true;
            gameObject.GetComponent<PlayerHealth>().SetHp(1);
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

    public bool GetMafia()
    {
        return mafiaPowerup;
    }
}
