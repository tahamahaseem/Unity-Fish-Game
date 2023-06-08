using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuFade : MonoBehaviour

{
    public Image blackFade;
    // Start is called before the first frame update
    void Start()
    {
        blackFade.canvasRenderer.SetAlpha(1.0f);

        fadeIn();
    }

    // Update is called once per frame
    void fadeIn()
    {
        blackFade.CrossFadeAlpha(0,5, false);
    }


}
