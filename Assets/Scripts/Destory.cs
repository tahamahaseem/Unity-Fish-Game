using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory : MonoBehaviour
{

    public AIHealth health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (health.currentHealth <= 0)
        {
            transform.position = new Vector3(0, -100000000, 0);
            Destroy(gameObject, 0.5f);
        }
    }

}
