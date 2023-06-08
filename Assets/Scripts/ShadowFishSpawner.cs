using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowFishSpawner : MonoBehaviour
{

    public GameObject smallFish;
    public Rigidbody2D rb;
    private float randomX = 0;
    private float randomY;
    private Vector3 spawnLocation;
    private float nextSpawn = 0.0f;
    public int numberOfSpawns = 10;
    private int spawnsOccured = 0;
    private float randomSize;
    public bool story = false;



    // Start is called before the first frame update
    void Start()
    {
        smallFish.transform.localScale = new Vector3(1,1,0);
    }

    // Update is called once per frame
    void Update(){
        randomX = 0;

        if (story)
        {
            randomSize = UnityEngine.Random.Range(0.05f, 0.2f);
        }
        else
        {
            randomSize = UnityEngine.Random.Range(1, 8);
        }

       
        smallFish.transform.localScale = new Vector3(randomSize, randomSize, 1);
        if (spawnsOccured != numberOfSpawns){
           
           
            spawnsOccured++;
            if (story)
            {
                randomX = UnityEngine.Random.Range(-7, 7);
                randomY = UnityEngine.Random.Range(-5, 5);
            }
            else
            {
                randomX = UnityEngine.Random.Range(-500, 500);
                randomY = UnityEngine.Random.Range(-300, 300);
            }

            spawnLocation = new Vector3(randomX,randomY,1);
            Instantiate(smallFish, spawnLocation, Quaternion.identity);
        }
   
    

        
    }
}
