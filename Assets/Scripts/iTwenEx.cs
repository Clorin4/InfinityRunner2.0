using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iTwenEx : MonoBehaviour
{
    public Transform target;
    public float moveDuration = 2.0f;


    private void Start()
    {
        if(target == null)
        {
            Debug.LogError("No se asigno un geimobjet");
            return;
        }
        // mover GO d un punto A a B
        Hashtable moveArgs = new Hashtable();
        moveArgs.Add("position", target.position);
        moveArgs.Add("time", moveDuration);
        moveArgs.Add("easetype", iTween.EaseType.easeInOutBack);
        iTween.MoveTo(gameObject, moveArgs);

        //FLASH
        Hashtable flashArgs = new Hashtable();
        flashArgs.Add("scale", new Vector3(1.3f, 1.3f, 1.3f));
        flashArgs.Add("time", moveDuration);
        flashArgs.Add("easetype", iTween.EaseType.easeInOutQuad);
        flashArgs.Add("looptype", iTween.LoopType.pingPong);
        iTween.ScaleTo(gameObject, flashArgs);

        /*FADE
        Hashtable fadeArgs = new Hashtable();
        fadeArgs.Add("alpha", 1f);
        fadeArgs.Add("time",moveDuration);
        fadeArgs.Add("easetype", iTween.EaseType.easeInOutQuint);
        iTween.FadeTo(gameObject, fadeArgs);/*

        /*ROTAR A to B
        Hashtable rotateArgs = new Hashtable();
        rotateArgs.Add("rotation", new Vector3(0f, 0f, 180f));
        rotateArgs.Add("time", moveDuration);
        rotateArgs.Add("easetype", iTween.EaseType.easeInOutQuint);
        iTween.RotateTo(gameObject, rotateArgs);*/

        /*COLOR
        Hashtable colorArgs = new Hashtable();
        colorArgs.Add("color", Color.magenta);
        colorArgs.Add("time", moveDuration);
        colorArgs.Add("easetype", iTween.EaseType.easeInOutQuint);
        iTween.ColorTo(gameObject, colorArgs);*/



    }
    
}
