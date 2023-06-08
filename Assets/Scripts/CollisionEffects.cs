using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEffects : MonoBehaviour
{
    public Transform particles;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        Destroy(gameObject, 20f);
    }

    // Update is called once per frame

   // private void OnCollisionEnter2D(Collision2D other)
    //{

    //    if ((other.gameObject.tag == "Eatable") || other.gameObject.tag == "Medium")
   //     {
   //         UnityEngine.Debug.Log(true);
   //         particles.GetComponent<ParticleSystem>().enableEmission = true;

   //     }


   // }

    void LateUpdate()
    {

    }
}
