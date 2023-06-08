using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Text timer;
    private float t;
    private string seconds, minutes;
    void Start()
    {
        t = Time.timeSinceLevelLoad;
        timer.canvasRenderer.SetAlpha(0f);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (player != null)
        {
            t = Time.timeSinceLevelLoad;

            timer.CrossFadeAlpha(1, 5, false);
            minutes = ((int)t / 60).ToString();
            seconds = (Mathf.Round(t % 60)).ToString();
            timer.text = "LifeTime " + minutes + " : " + seconds;
        }
        else
        {
            timer.text = "You Survived " + minutes + " minutes and " + seconds + " seconds";
        }
    }
}
