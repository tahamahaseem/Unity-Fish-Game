using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using UnityEngine;

public class MediumMovement : MonoBehaviour
{
    public GameObject fish;
    private GameObject player;
    public Animator animator;
    private Vector2 velocity;
    private float randomX, randomY, locationX, locationY;
    public float movementX, movementY;
    public float boundX, boundY;
    public float defaultSpeed;
    public float knockbackPower = 5;
    private float speed;
    private float change = 2;
    private Vector3 location;
    private float apart;
    private float randomSize;
    private float count = 0;
    public AudioSource audioS;
    public AudioClip bite;
    public Transform biteEffect;
    public bool neutral = false;
    private bool detected = false;
    public bool harmless = false;
    public float maxSize;
    public float minSize;
    //public static MediumMovement instance = null;
    //public Rigidbody2D rb;


    private void OnCollisionEnter2D(Collision2D other)
    {

        if (harmless == false)
        {
            if (other.gameObject.tag == "Eatable")
            {
                StartCoroutine(other.gameObject.GetComponent<EatableMovement>().knockBack(knockbackPower, fish.transform));
                animator.SetBool("Bite", true);
                Instantiate(biteEffect, other.transform.position, Quaternion.Euler(0, 0, 0));

            }

            if (other.gameObject.tag == "Player")
            {

                StartCoroutine(other.gameObject.GetComponent<StoryMovement>().knockBackPlayer(knockbackPower, fish.transform));
                animator.SetBool("Bite", true);
                audioS.PlayOneShot(bite);
                Instantiate(biteEffect, other.transform.position, Quaternion.Euler(0, 0, 0));
            }
        }
        else
        {
            Physics2D.IgnoreCollision(fish.gameObject.GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>());
        }

    }



        // Start is called before the first frame update
        void Start()
    {
       
        change = 0;
        randomSize = UnityEngine.Random.Range(minSize,maxSize);
        transform.localScale = new Vector3(randomSize,randomSize,1);
        randomY = 0;
        randomX = 0;
        locationX = transform.position.x + randomX;
        locationY = transform.position.y + randomY;
        speed = defaultSpeed;
        change = 0;
    }


    void Update()
    {
      
        if (animator.GetBool("Bite") == true)
        {
            count++;
                if (count >= 30)
            {
                count = 0;
                animator.SetBool("Bite", false);

            }
        }

        


       



        if (Vector3.Distance(transform.position, location) < change && (detected == false))
        {

            change = 2;
            speed = defaultSpeed;
            randomY = UnityEngine.Random.Range(-movementY, movementY);
            randomX = UnityEngine.Random.Range(-1, 2) * UnityEngine.Random.Range(20, movementX);

            if ((transform.position.x < -boundX))
            {
                randomX = UnityEngine.Random.Range(0, movementX);
            }
            else if (transform.position.x > boundX)
            {
                randomX = UnityEngine.Random.Range(-movementX, 0);
            }
            if (transform.position.y < -boundY)
            {
                randomY = UnityEngine.Random.Range(0, movementY);
            }
            else if (transform.position.y > boundY)
            {
                randomY = UnityEngine.Random.Range(-movementY, 0);
            }

            locationX = transform.position.x + randomX;
            locationY = transform.position.y + randomY;
            animator.SetFloat("Horizontal", randomX);
            animator.SetFloat("Vertical", randomY);

        }
        else
        {
           speed = defaultSpeed;
           animator.SetFloat("Horizontal", randomX);
           animator.SetFloat("Vertical", randomY); 
        }
        change = change + 0.1f;
        location = new Vector3(locationX, locationY, 1);


        player = GameObject.FindGameObjectWithTag("Player");
        
        if ((Vector3.Distance(player.GetComponent<StoryMovement>().transform.position, transform.position) <= 5) && neutral == false)
        {
            detected = true;
            locationX = player.GetComponent<StoryMovement>().transform.position.x;
            locationY = player.GetComponent<StoryMovement>().transform.position.y;

            animator.SetFloat("Horizontal", player.GetComponent<StoryMovement>().transform.position.x - (transform.position.x));
            animator.SetFloat("Vertical", player.GetComponent<StoryMovement>().transform.position.y - (transform.position.y));

            if (Vector3.Distance(player.GetComponent<StoryMovement>().transform.position, transform.position) <= 2)
            {
                speed = defaultSpeed / 15;

            }
            else
            {
                speed = defaultSpeed / 10;
            }

        }
            detected = false;


    }

    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, locationX, ref velocity.x, speed * Time.deltaTime);
        float posY = Mathf.SmoothDamp(transform.position.y, locationY, ref velocity.y, speed * Time.deltaTime);
        transform.position = new Vector3(posX, posY, 1);
    }


}

