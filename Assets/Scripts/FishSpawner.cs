using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{

    public GameObject smallFish;
    public bool depthSpawn = true;
    private float randomX;
    private float randomY;
    private Vector3 spawnLocation;
    public float spawnRate = 2.0f;
    private float nextSpawn = 0.0f;
    public int numberOfSpawns = 10;
    private int spawnsOccured = 0;
    private float side = 0;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update(){
        
        if ((Time.time > nextSpawn) && (spawnsOccured != numberOfSpawns))
        {
            
            spawnsOccured++;
           
            randomY = UnityEngine.Random.Range(-5,5);
            if (depthSpawn)
            {
                randomX = UnityEngine.Random.Range(-500, 500);
            }
            else
            {
                
                randomX = 0;
                while (randomX == 0)
                {

                    randomX = UnityEngine.Random.Range(-1, 2) * 5;
                }
                
            }
            nextSpawn = Time.time + spawnRate;
            spawnLocation = new Vector3(randomX,randomY,1);
            Instantiate(smallFish, spawnLocation, Quaternion.identity);
        }
   
    

        
    }
}
