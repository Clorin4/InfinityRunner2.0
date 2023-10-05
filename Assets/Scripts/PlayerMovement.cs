using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
[SerializeField]
    public float jumpforce = 1000f;
    private Rigidbody2D playerRB;
    public LayerMask groundMask;
    public bool grounded;
    public float speed = 1000f;
    [SerializeField] private float runningSpeed = 2f;
    Vector3 startPosition;

    public bool gameover = false;
    public float velCaida;
    public float increVel;
    public float lapsoNvl;
    public float increLapso;
    public float tiempo;

    public GameObject Player;
    public GameManager GM;

    [SerializeField] private float cantPuntos;
    [SerializeField] private Coins coin;

    //SALTO
    public Rigidbody2D rbd;
    public float Fuerza;
    public bool TocandoSuelo;
    public bool statusSalto;

    [Header("Salto")]
    private Animator animator;


    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        
    }

    private void Start()
    {
        startPosition = this.transform.position;
        animator = GetComponent<Animator>();
    }

    public void StartGame()
    {
        this.transform.position = startPosition;
        this.playerRB.velocity = Vector2.zero;
    }

    private void Update()
    {
        Debug.DrawRay(this.transform.position, Vector2.down * 2.0f, Color.red);

        tiempo = Time.timeSinceLevelLoad;
        if (tiempo > lapsoNvl)
        {
            runningSpeed += increVel;
            lapsoNvl += increLapso;
        }

        else if (Input.GetKeyDown(KeyCode.Space) && TocandoSuelo == true)
        {
            Saltar();
        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && TocandoSuelo == true)
        {
            Saltar();
        }

        statusSalto = AudioManager.sharedInstance.salto;


    }

     void FixedUpdate()
    {
        if(playerRB.velocity.x < runningSpeed)
        {
            playerRB.velocity = new Vector2(runningSpeed, playerRB.velocity.y);
        }

        animator.SetBool("TocandoSuelo", TocandoSuelo);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "KillZone")
        {
            PlayerMovement movement = collision.GetComponent<PlayerMovement>();
            //movement.Die();
            Debug.Log("MORISTE");
            GM.GameOver();

            if (!MuteButton.sharedInstance.isMuted)
            {
                AudioManager.sharedInstance.GameOverAudioOn();
            }

        }

        if (collision.tag == "Coin")
        {
            PlayerMovement movement = collision.GetComponent<PlayerMovement>();
            Debug.Log("MONEDA");
            coin = FindAnyObjectByType<Coins>();
            coin.SMRPNTS();

            if (!MuteButton.sharedInstance.isMuted)
            {
                AudioManager.sharedInstance.CoinAudioOn();
            }

        }

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
        animator.SetBool("TocandoSuelo", TocandoSuelo);
        TocandoSuelo = false;

        if (!MuteButton.sharedInstance.isMuted)
        {
            AudioManager.sharedInstance.JumpAudioOn();
        }

    }

}
