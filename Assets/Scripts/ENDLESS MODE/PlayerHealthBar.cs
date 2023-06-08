using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
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
            fill.color = Color.green;
            }
            slider.value = fillValue;

        transform.position = new Vector3(character.transform.position.x + -90, character.transform.position.y + 88, 1);



    }
}

