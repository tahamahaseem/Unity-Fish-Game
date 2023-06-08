using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject player;
    public Rigidbody2D rb;
    public Animator animator;
    public Transform collisionEffect;
    private float counter = 0;
    private float defaultSize;
    private bool waitForIdle = false;
    private bool spawn = true;
    public AudioSource audioS;
    public AudioClip errupt;

    // Start is called before the first frame update
    void Start()
    {
       // defaultSize = player.transform.localScale.x;
        player.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y+1,1);
        player.SetActive(false);
        //player.transform.localScale = new Vector3(0,0,0);

    }


    // Update is called once per frame
    void Update()
    {

        
        
        if(animator.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Spawning") == true){
            waitForIdle = true;

            if (spawn)
            {
                audioS.PlayOneShot(errupt);
                spawn = false;
            }

        }
        if (waitForIdle)
        {
            if (animator.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("ErruptionComplete") == true)
            {
                player.SetActive(true);
                Instantiate(collisionEffect, new Vector3(transform.position.x, transform.position.y+0.8f, transform.position.z), Quaternion.Euler(0, 0, 180));
                waitForIdle = false;
                rb.AddForce(new Vector3(0, 4, 0), ForceMode2D.Impulse);
   
            }
        }
      



    }

}
