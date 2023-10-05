using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{

    public Rigidbody2D rbd;
    public float Fuerza;
    public bool TocandoSuelo;
    public bool statusSalto;


    [Header("Salto")]
    private Animator animator;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && TocandoSuelo == true)
        {
            Saltar();
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && TocandoSuelo == true)
        {
            Saltar();
        }

        statusSalto = AudioManager.sharedInstance.salto;
    }

    private void OnCollisionEnter2D(Collision2D LaCosa)
    {
        if (LaCosa.gameObject.tag == "Ground")
        {
            TocandoSuelo = true;
        }
    }

    private void Saltar()
    {
        rbd.AddForce(Vector2.up * Fuerza, ForceMode2D.Impulse);
        TocandoSuelo = false;

        if (!MuteButton.sharedInstance.isMuted)
        {
            AudioManager.sharedInstance.JumpAudioOn();
        }

    }

}
