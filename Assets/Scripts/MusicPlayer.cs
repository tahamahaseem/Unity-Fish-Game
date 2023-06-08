using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    public AudioSource audioS; 
    public float timeStamp;

    // Start is called before the first frame update
    void Start()
    {
        audioS.time = timeStamp;
        audioS.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
