using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using UnityEngine;

public class ShadowFishMovement : MonoBehaviour
{
    public GameObject fish;
    public Animator animator;
    private Vector2 velocity;
    private float randomX, randomY, locationX, locationY;
    public float defaultSpeed = 2f;
    private float speed;
    public float boundX = 320;
    public float boundY = 160;
    public float movementX = 200;
    public float movementY = 100;
    private Vector3 location;
    private double change = 40;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;

        randomX = Random.Range(-100, 100);
        randomY = Random.Range(-100, 100);
        locationX = transform.position.x + randomX;
        locationY = transform.position.y + randomY;
        speed = defaultSpeed;
       

    }


    void Update()
    {
        //Debug.Log(speed);
        animator.SetFloat("Horizontal", randomX);
        animator.SetFloat("Vertical", randomY);
        float posX = Mathf.SmoothDamp(transform.position.x, locationX, ref velocity.x, speed);
        float posY = Mathf.SmoothDamp(transform.position.y, locationY, ref velocity.y, speed);
  

        if ((Vector3.Distance(transform.position, location) < change))
            {

                change = 40;
                speed = defaultSpeed;
                randomY = Random.Range(-movementY / 2, movementY / 2);
                randomX = Random.Range(-movementX / 2, movementX / 2);

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
        }

       
       
            location = new Vector3(locationX, locationY, 1);
            transform.position = new Vector3(posX, posY, 1);
            change = change + 0.1;
    }

}

