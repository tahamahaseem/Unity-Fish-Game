using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{

    Vector2 mouseCoordinates;
    float mouseDirectionY, mouseDirectionX;
    public Transform crosshair;

    // Start is called before the first frame update
    void Start()
    {  
    Cursor.visible = false;         
    }

 private void OnCollisionEnter2D(Collision2D other)
    {
        
        
        Physics2D.IgnoreCollision(this.gameObject.GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>());
        Debug.Log("BIG");
        if (other.gameObject.tag == "Eatable")
        {
            //Physics2D.IgnoreCollision(fish.gameObject.GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>());
        }

       


    }


    // Update is called once per frame
    void Update()
    {
      
        mouseDirectionY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
        mouseDirectionX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        mouseCoordinates = new Vector2(mouseDirectionX, mouseDirectionY);
        crosshair.position = mouseCoordinates;
        

    }
}
