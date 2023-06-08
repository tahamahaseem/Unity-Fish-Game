using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class StoryAbilityBar : MonoBehaviour
{
    public Transform character;
    public Image fill;
    private float max;
    private Slider slider;
    public StoryMovement boost;
    public float x, y;

    void Awake()
    {
        slider = GetComponent<Slider>();
        max = boost.boostTime;
    }


    void FixedUpdate()
    {
        

        float fillValue = boost.boostTime / max;
        if ((slider.value <= slider.minValue))
            {
                fill.enabled = false;
            }
            else
            {
                fill.enabled = true;
            }

   
        slider.value = fillValue;
        //transform.position = new Vector3(character.transform.position.x - x, character.transform.position.y + y, 1);



    }
}

