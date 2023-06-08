using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class StoryMovement : MonoBehaviour
{
    public Animator tailAnimator;
    public Animator headAnimator;
    public Transform player;
    public float speed;
    public AIHealth health;
    private float defaultSpeed;
    public float knockbackPower = 10;
    private float knockBackPowerOnBoost;
    private float knockBackDefault;
    public float boostTime;
    public bool boost = false;
    public TrailRenderer boostTrail;
    public Transform collisionEffect;
    public Transform blood;
    public Rigidbody2D rb2d;

    public float boostDuration;



    public static StoryMovement instance = null;

    private void OnCollisionEnter2D(Collision2D other){

       
        if (other.gameObject.tag == "Eatable"){
           // if ((Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0)) {
            StartCoroutine(other.gameObject.GetComponent<EatableMovement>().knockBack(knockbackPower, player));
            headAnimator.SetBool("Bite", false);
            player.transform.position = Vector3.MoveTowards(player.transform.position, -player.transform.position * 100, speed * Time.deltaTime);
            if (health.currentHealth < health.maxHealth)
            {
                health.currentHealth = health.currentHealth + 0.05f;
            }
            //UnityEngine.Debug.Log(headAnimator.GetBool("Bite"));
            // }

        }
        

    }


    void Awake()
    {
        //QualitySettings.vSyncCount = 1;
        //Application.targetFrameRate =-1;
    }

    void Start()
       {
        defaultSpeed = speed;
        boostTrail.emitting = false;
        knockBackPowerOnBoost = knockbackPower * 2;
        knockBackDefault = knockbackPower;
        //rb2d.velocity = new Vector2(2.0f, 2.0f);

    }

    // Update is called once per frame
    

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0.0f);
        //Debug.Log(Input.GetAxis("Horizontal"));
    if (Input.GetAxis("Horizontal") > 0){
        tailAnimator.SetBool("Side",true);
        headAnimator.SetBool("Side", true);
        }
    else if (Input.GetAxis("Horizontal") < 0){
        tailAnimator.SetBool("Side",false);
        headAnimator.SetBool("Side", false);
        }
     tailAnimator.SetFloat("Horizontal", movement.x);
     tailAnimator.SetFloat("Vertical", movement.y);
     tailAnimator.SetFloat("Magnitude", movement.magnitude);
     headAnimator.SetFloat("Horizontal", movement.x);
     headAnimator.SetFloat("Vertical", movement.y);
     headAnimator.SetFloat("Magnitude", movement.magnitude);


     transform.position = transform.position + movement * (speed * Time.deltaTime);

        if ((Input.GetKeyDown("space") == true) && (boost == false) && (boostTime >= (boostDuration - 8)))
        {
            rb2d.AddForce(movement * 8, ForceMode2D.Impulse);
            boost = true;
            boostTrail.emitting = true;
            boostTime = 0f;
        }



    }

    void FixedUpdate()
    {

        if (boostTime >= 50){
            boostTrail.emitting = false;
        }
        
        if (boost == true)
        {
            speed = speed - 0.5f;

            if (speed <= defaultSpeed)
            {
                boost = false;
                speed = defaultSpeed;
            }

        }
        else
        {
            if (boostTime <= 200){
            boostTime++;
            }
        }
    }


    void LateUpdate()
    {
        headAnimator.SetBool("Bite", false);
       // transform.position = new Vector3(Mathf.Clamp(transform.position.x, -460, 460), Mathf.Clamp(transform.position.y, -260, 260), Mathf.Clamp(transform.position.z, 1, 1));

    }

    public IEnumerator knockBackPlayer(float knockbackPower, Transform obj)
    {
     
           
            //trail.emitting = true;

            Vector3 direction = -(obj.transform.position - this.transform.position).normalized;

        //location = (transform.position.x + (direction.x * 100), transform.position.y + (direction.y * 100));
        //speed = defaultSpeed / knockbackPower;
        //health.currentHealth--;
            float angle = (Mathf.Atan2(direction.x, -direction.y) * Mathf.Rad2Deg);
            Instantiate(collisionEffect, transform.position, Quaternion.Euler(0, 0, angle));
            health.currentHealth--;
            rb2d.AddForce(direction * 12, ForceMode2D.Impulse);
        if (health.currentHealth <= 0)
            {
                Instantiate(blood, transform.position, Quaternion.Euler(0, 0, angle));
                Instantiate(collisionEffect, transform.position, Quaternion.Euler(0, 0, angle));

        }

            if (health.currentHealth > 0)
            {
                Instantiate(collisionEffect, transform.position, Quaternion.Euler(0, 0, angle));
        }

       
        

        yield return 0;

    }


}
    
