using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using UnityEngine;

public class EatableMovement : MonoBehaviour
{
    private GameObject player;
    public GameObject fish;
    public Animator animator;
    private Vector2 velocity;
    private float randomX, randomY, locationX, locationY, fleeLocationX, fleeLocationY;
    public float defaultSpeed = 2f;
    private float speed;
    public float boundX = 320;
    public float boundY = 160;
    public float movementX = 200;
    public float movementY = 100;
    private float fleeMovementX, fleeMovementY, idleMovementX, idleMovementY;
    private Vector3 location;
    public AudioSource audioS;
    public AudioClip bite;
    public AudioClip pop;
    public AIHealth health;
    private double change = 20;
    public TrailRenderer trail;
    public Transform collisionEffect;
    public Transform blood;
    public float fleeDistance = 60;
    public bool immune = true;
    float deplete, posX, posY;
    private Vector3 fleeDirection;
    
    private Vector3 playerPos;


    public static EatableMovement instance = null;
    public Rigidbody2D rb;

    private void Awake()
    {

        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnCollisionEnter2D(Collision2D other)
    {


        if (other.gameObject.tag == "Eatable")
        {
            Physics2D.IgnoreCollision(fish.gameObject.GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>());
        }else{
            basicDestination();
            change = 20;

        }

       


    }

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;

        randomY = 0;
        randomX = 0;
        locationX = transform.position.x + randomX;
        locationY = transform.position.y + randomY;
        speed = defaultSpeed;
    }


    void Update()
    {
        Debug.Log(location);

        if ((animator.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("SpawnLeft") == true) || (animator.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("SpawnRight") == true))
        {
            immune = false;
        }

        


    }

    void FixedUpdate()
    {
        posX = Mathf.SmoothDamp(transform.position.x, locationX, ref velocity.x, speed * Time.deltaTime);
        posY = Mathf.SmoothDamp(transform.position.y, locationY, ref velocity.y, speed * Time.deltaTime);
        playerPos = player.transform.position;
        transform.position = new Vector3(posX, posY, 1);
         change = change + 0.1;
        if(Mathf.Abs(playerPos.x-transform.position.x) <=4 && Mathf.Abs(playerPos.y-transform.position.y)<=4){
            flee();
        }else{
            
        if ((Vector3.Distance(transform.position, location) < change))
        {
            basicDestination();
            }
            
        }
        animator.SetFloat("Horizontal", randomX);
        animator.SetFloat("Vertical", randomY);
       

    }


        public IEnumerator knockBack(float knockbackPower, Transform obj)
    {
        if (immune == false)
        {
            if (obj.gameObject.CompareTag("Player") == true)
            {
                audioS.PlayOneShot(bite);
                deplete = 1f;
            }
            if (obj.gameObject.CompareTag("Projectile") == true)
            {
                 deplete = 0.5f;
            }
            health.currentHealth = health.currentHealth - deplete;
            Vector3 direction = -(obj.transform.position - this.transform.position).normalized;
            float angle = (Mathf.Atan2(direction.x, -direction.y) * Mathf.Rad2Deg);
            if (health.currentHealth <= 0)
            {
                fish.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
                Instantiate(blood, transform.position, Quaternion.Euler(0, 0, angle));
                Instantiate(collisionEffect, transform.position, Quaternion.Euler(0, 0, angle));


            }

            if (health.currentHealth > 0)
            {
               
                change = 1;
               
               
                rb.AddForce(direction *12, ForceMode2D.Impulse);


                Instantiate(collisionEffect, transform.position, Quaternion.Euler(0, 0, angle));
            }
           
        }
        yield return 0;

    }

    public void basicDestination(){

             change = 20;
                speed = defaultSpeed;
                trail.emitting = false;
                randomY = Random.Range(-movementY, movementY);
                randomX = Random.Range(-1, 2) * Random.Range(20, movementX);
            if (randomX == 0)
            {
                randomX = Random.Range(10, movementX);
            }

                if ((transform.position.x < -boundX))
                {
                    randomX = Random.Range(0, movementX);
                }
                else if (transform.position.x > boundX)
                {
                    randomX = Random.Range(-movementX, 0);
                }
                if (transform.position.y < -boundY)
                {
                    randomY = Random.Range(0, movementY);
                }
                else if (transform.position.y > boundY)
                {
                    randomY = Random.Range(-movementY, 0);
                }

                locationX = transform.position.x + randomX;
                locationY = transform.position.y + randomY;

        location = new Vector3(locationX, locationY, 1);


    }

    public void flee(){
        Debug.Log("RUN");
        change = 20;
        fleeDirection = (new Vector3(playerPos.x - transform.position.x, playerPos.y - transform.position.y, transform.position.z).normalized)*movementX;
        speed = defaultSpeed/2;
        locationX = -(transform.position.x + (fleeDirection.x));
        //locationY = -(transform.position.y + (fleeDirection.y));
        location = new Vector3(locationX, locationY, 1);
        randomX = locationX - transform.position.x;
        randomY = locationY - transform.position.y;


        
        //transform.position = new Vector3(posX, posY, 1);
        
    }

}

