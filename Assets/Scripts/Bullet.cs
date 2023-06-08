using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

public GameObject bullet;
public Transform projectile;
public Transform bubblePop;
public AudioSource audioS;
public AudioClip pop;


    private void OnCollisionEnter2D(Collision2D other)
    {
  
        if (other.gameObject.tag == "Eatable"){
           // if ((Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0)) {
            StartCoroutine(other.gameObject.GetComponent<EatableMovement>().knockBack(2, projectile));}

        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Projectile" )
        {
            Instantiate(bubblePop, transform.position, Quaternion.Euler(0, 0, 0));
            audioS.PlayOneShot(pop);
            transform.position = new Vector3 (0,-100000000000,1);
            Destroy(gameObject, 3f);
        }
    
            
   
      



    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
