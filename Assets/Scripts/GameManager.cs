using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public enum GameState
{
    menu,
    inGame,
    pause,
    gameOver
}

public class GameManager : MonoBehaviour
{
    public static int puntosTotales = 0;
    public TextMeshProUGUI textMeshPro;

    public bool isPause = false;
    public bool isGame = true;
    public bool isGameOver = false;

    public GameObject PauseObjects;
    public GameObject GameOverObj;
    public GameObject ResumeBtton;
    public GameObject PauseBtton;
    public Button botonSalir;
    public Button botonSalir2;

    //public AudioSource backgroundAudio;

    public static GameManager sharedInstance;
    [SerializeField] GameState currentGameState;
    public PlayerMovement movement;

    private void Awake()
    {
        Time.timeScale = 1f;
        isGame = true;
        if (sharedInstance == null)
            sharedInstance = this;
    }

    void Start()
    {
        Time.timeScale = 1f;
        isGame = true;
        currentGameState = GameState.inGame;
        movement = GameObject.Find("Player").GetComponent<PlayerMovement>();

        PauseObjects.SetActive(false);

        botonSalir.onClick.AddListener(Salir);
        botonSalir2.onClick.AddListener(Salir);
    }

    private void Update()
    {
        textMeshPro.text = "Puntos Totales: " + puntosTotales.ToString();

        if (Input.GetKeyDown(KeyCode.P))
        {
            
            if (isPause)
                ResumeGame();
            else
                PauseGame();
        }

    }


    public void PauseGame()
    {
        isPause = true;
        isGame = false;
        Time.timeScale = 0f;
        PauseObjects.SetActive(true);
        //backgroundAudio.Pause();
        AudioManager.sharedInstance.BackgroundSoundOff();
        currentGameState = GameState.pause;
        PauseBtton.SetActive(false);
        ResumeBtton.SetActive(true);


    }

    public void ResumeGame()
    {
        isPause = false;
        isGame = true;
        Time.timeScale = 1f;
        PauseObjects.SetActive(false);
        currentGameState = GameState.inGame;
        PauseBtton.SetActive(true);
        ResumeBtton.SetActive(false);
        if (!MuteButton.sharedInstance.isMuted)
        {
            AudioManager.sharedInstance.BackgroundSoundOn();
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        isGame = false;
        Time.timeScale = 0f;
        PauseObjects.SetActive(false);
        GameOverObj.SetActive(true);
        AudioManager.sharedInstance.BackgroundSoundOff();
        //backgroundAudio.Pause();
        currentGameState = GameState.gameOver;

    }

    public void Salir()
    {
        // Salir del juego (solo en móviles, no en el Editor)
        Application.Quit();
    }

}