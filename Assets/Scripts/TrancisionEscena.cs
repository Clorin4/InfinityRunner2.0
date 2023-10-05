using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrancisionEscena : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private AnimationClip FADE;

    public Button botonSalir;

    void Start()
    {
        animator = GetComponent<Animator>();
        botonSalir.onClick.AddListener(Salir);

    }

    private void Update()
    {
        /*if(Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //animacion

            //sig escena
        }*/
    }

    public void NextScene()
    {
        StartCoroutine(CambiarEscena());
    }


    IEnumerator CambiarEscena()
    {
        Time.timeScale = 1f;
        animator.SetTrigger("Iniciar");
        yield return new WaitForSeconds(FADE.length);

        SceneManager.LoadScene(1);
    }



    public void NextScene2()
    {
        StartCoroutine(CambiarEscena2());
    }
    //

    IEnumerator CambiarEscena2()
    {
        Time.timeScale = 1f;
        Debug.Log("CORRUTINA2");
        animator.SetTrigger("Iniciar");
        yield return new WaitForSeconds(FADE.length);

        SceneManager.LoadScene(0);
    }

    public void Salir()
    {
        Application.Quit();
    }


}
