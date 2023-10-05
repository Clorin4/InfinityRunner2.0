using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public float dlay = 1f;

    public void NextScene()
    {

       SceneManager.LoadScene(1);
       // StartCoroutine(LoadSceneWithDelay());
    }

   /* IEnumerator LoadSceneWithDelay()
    {
        yield return new WaitForSeconds(dlay);
        SceneManager.LoadScene(1);
    }*/
}
