using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager sharedInstance;
    public Canvas pauseCanvas;
    public Canvas DeadCanvas;

    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
    }
    public void ShowPauseCanvas()
    {
        pauseCanvas.enabled = true;
    }
    
    public void HidePauseCanvas()
    {
        pauseCanvas.enabled = false;
    }

    public void ShowDeadCanvas()
    {
        DeadCanvas.enabled = true;
    }

    public void HideDeadCanvas()
    {
        DeadCanvas.enabled = false;
    }


    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    /*public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Aplication.Quit();
#endif
    }*/
}
