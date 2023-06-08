using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

public class FindEatable : MonoBehaviour
{
    public Transform player;
    public Animator headAnimator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FindClosestEatable();
    }

    void FindClosestEatable()
    {
        float distanceToClosestEatable = Mathf.Infinity;
        Eatable closestEatable = null;
        Eatable[] allEatables = GameObject.FindObjectsOfType<Eatable>(); 

        foreach (Eatable currentEatable in allEatables)
        {
            float distanceToEatable = (currentEatable.transform.position - this.transform.position).sqrMagnitude;
            if(distanceToEatable < distanceToClosestEatable)
            {
                distanceToClosestEatable = distanceToEatable;
                closestEatable = currentEatable;

            }
        }
            if (Vector3.Distance(player.transform.position, closestEatable.transform.position) <= 1f){
            headAnimator.SetBool("Bite", true);
        }
        if (Vector3.Distance(player.transform.position, closestEatable.transform.position) > 1f){
            headAnimator.SetBool("Bite", false);
        }
        

    }
}