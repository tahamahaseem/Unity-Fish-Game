using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    public Transform character;
    public AIHealth health;
    public Image fill;
    public float barSpacingY = 10;
    public float barSpacingX = 0;
    private Slider slider;
    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
        transform.position = new Vector3(-10000 ,0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (health.currentHealth != health.maxHealth)
        {
            
            if ((slider.value <= slider.minValue))
            {
                fill.enabled = false;
            }
            else
            {
                fill.enabled = true;
            }

            float fillValue = health.currentHealth / health.maxHealth;
            if (fillValue <= slider.maxValue / 2)
            {
                fill.color = Color.red;
            }
            else
            {
                fill.color = Color.green;
            }
            slider.value = fillValue;

            transform.position = new Vector3(character.transform.position.x + barSpacingX, character.transform.position.y + barSpacingY, 1);
        }

        

    }
}

