using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    float bulletSpeed = 20f;
    public Animator Animator;
    GameObject bulletClone;

    Vector2 mouseCoordinates, playerCoordinates, spawnCoordinates;
    float resultant,mouseDirectionY, mouseDirectionX, playerDirectionY, playerDirectionX, spawnCoordinateX, spawnCoordinateY, unitX, unitY, distanceAwayFromPlayer;
    

    void Update()
    {

        //OnCollisionEnter2D(GameObject.firePoint);

        distanceAwayFromPlayer = 0.4f;
        mouseDirectionY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
        mouseDirectionX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        mouseCoordinates = new Vector2(mouseDirectionX, mouseDirectionY);
        playerDirectionX = firePoint.position.x;
        playerDirectionY = firePoint.position.y;
        playerCoordinates = new Vector2(playerDirectionX, playerDirectionY);
        spawnCoordinateX = (mouseDirectionX - playerDirectionX);
        spawnCoordinateY = (mouseDirectionY - playerDirectionY);
        spawnCoordinates = new Vector2(mouseDirectionY, mouseDirectionX);
        resultant =  Mathf.Pow(Mathf.Pow(spawnCoordinateX,2f)+Mathf.Pow(spawnCoordinateY,2f),0.5f);
        unitX = spawnCoordinateX/resultant*distanceAwayFromPlayer;
        unitY = spawnCoordinateY/resultant*distanceAwayFromPlayer;
        


if (Input.GetMouseButtonDown(0)){
        if ((Animator.GetBool("Side") == true) && spawnCoordinateX > -0.2)
        {
             GameObject bulletClone = Instantiate(bullet);
             bulletClone.transform.position = new Vector2(playerDirectionX+unitX, playerDirectionY+unitY);
             bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(unitX, unitY)*bulletSpeed;
         }
          if ((Animator.GetBool("Side") == false) && spawnCoordinateX < 0.2)
        {
             bulletClone = Instantiate(bullet);
             bulletClone.transform.position = new Vector2(playerDirectionX+unitX, playerDirectionY+unitY);
             bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(unitX, unitY)*bulletSpeed;
         }
         Debug.Log(Animator.GetBool("Side"));
    }
    }
}
