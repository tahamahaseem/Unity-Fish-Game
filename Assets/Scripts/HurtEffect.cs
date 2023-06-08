using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
public class HurtEffect : MonoBehaviour
{
    public AIHealth health;
    public Image effect;
    private float current;
    private float lost;
    private bool hurt;
    private float timer;
   
    // Start is called before the first frame update
    void Start()
    {
        effect.canvasRenderer.SetAlpha(0f);
        current = health.currentHealth;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (health.currentHealth < current)
        {
            hurt = true;
            playHurt();
            
        }
        else
        {

        }

       
    }

    void FixedUpdate()
    {
        if (hurt)
        {
            timer++;
            if (timer > 10)
            {
                timer = 0;
                hurt = false;
                effect.CrossFadeAlpha(0, 0.2f, false);
            }
        }
    }

    void LateUpdate()
    {
        current = health.currentHealth;
    }

    void playHurt()
    {
        effect.CrossFadeAlpha(1, 0.1f, false);
        
    }
}
