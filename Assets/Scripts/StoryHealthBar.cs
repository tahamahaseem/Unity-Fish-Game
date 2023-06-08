using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class StoryHealthBar : MonoBehaviour
{
    public Transform character;
    public AIHealth health;
    public Image fill;
    public float barSpacingY = 10;
    public float barSpacingX = 0;
    private Slider slider;

    public float x,y;

    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
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
            fill.color = Color.cyan;
            }
            slider.value = fillValue;

        //transform.position = new Vector3(character.transform.position.x - x, character.transform.position.y + y, 1);



    }
}

