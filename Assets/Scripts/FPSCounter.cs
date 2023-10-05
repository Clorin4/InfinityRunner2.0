using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    public Text fpsText;
    private float delaTime = 0.0f;

    private void Update()
    {
        delaTime += (Time.deltaTime - delaTime) * 0.1f;
        float fps = 1.0f / delaTime;

        string fpsString = string.Format("{0:0} FPS", fps);
        fpsText.text = fpsString;

    }

}
