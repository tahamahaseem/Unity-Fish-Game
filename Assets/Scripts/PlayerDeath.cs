using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public AudioSource audioS;
    private float startVolume;
    private float FadeTime = 2;
    public AIHealth health;
    // Start is called before the first frame update
    void Start()
    {
        startVolume = audioS.volume;
    }

    // Update is called once per frame
    void Update()
    {
        



        //audioS.volume = startVolume;
        if (health.currentHealth <= 0)
        {
            Destroy(gameObject, 0f);


            //while (audioS.volume > 0)
            //{
              //  audioS.volume = startVolume - 0.1f;
            //}
            //audioS.Stop();
        }
    }
}
