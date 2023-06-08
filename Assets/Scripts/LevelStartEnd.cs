using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelStartEnd : MonoBehaviour

{
    public GameObject gameObject;
    public Image blackFade;
    public AudioSource audioS;
    public AudioClip bite;
    private bool once = true;
    // Start is called before the first frame update
    void Start()
    {
        blackFade.canvasRenderer.SetAlpha(1f);

        fadeIn();
    }

    // Update is called once per frame
    void fadeIn()
    {
        blackFade.CrossFadeAlpha(0, 4, false);
    }

    void fadeOut()
    {
        blackFade.CrossFadeAlpha(1, 0.5f, false);
    }

    void Update()
    {
        if (gameObject == null)
        {
            fadeOut();
            if (once)
            {
                audioS.PlayOneShot(bite);
                once = false;
            }
        }
    }
}
