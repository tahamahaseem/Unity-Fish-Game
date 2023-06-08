using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBoostBar : MonoBehaviour
{
    public Transform character;
    public Image fill;
    private float max;
    private Slider slider;
    public BasicMovement boost;

    void Awake()
    {
        slider = GetComponent<Slider>();
        max = boost.boostTime;
    }


    void FixedUpdate()
    {
        UnityEngine.Debug.Log(boost.boostTime);

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
        transform.position = new Vector3(character.transform.position.x - 110, character.transform.position.y + 81, 1);



    }
}

