using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    private GameObject _StartButton;
    private GameObject _ControlsButton;
    private GameObject _BackButton;
    private GameObject _ControlsPanel;
    private GameObject _GameMenuCanvas;
    private AudioManager audioManager;
    private bool gamePaused = false; 

    // Start is called before the first frame update
    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        _StartButton = GameObject.Find("StartButton");
        _ControlsButton = GameObject.Find("ControlsButton");
        _BackButton = GameObject.Find("BackButton");
        _ControlsPanel = GameObject.Find("ControlsPanel");
        _GameMenuCanvas = GameObject.Find("GameMenuCanvas");

        if (_GameMenuCanvas)
            _GameMenuCanvas.SetActive(false);

        if(_ControlsPanel)
            _ControlsPanel.SetActive(false);
        
        if(_BackButton)
            _BackButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Skip();
        PauseMenuCheck();
    }

    // Allows the player to skip the intertitle before the game starts
    private void Skip()
    {
        if (Input.GetKeyDown("space"))
        {
            if(SceneManager.GetActiveScene().name.Equals("Intertitle"))
            {
                audioManager.StopCurrent();
                SceneManager.LoadScene("Main");
            }

        }
    }

    // Pressing Escape while in the game brings up a pause menu
    private void PauseMenuCheck()
    {
        // If pause menu is already open, then continue the game
        if (Input.GetKeyDown("escape") && SceneManager.GetActiveScene().name.Equals("Main") && gamePaused)
            ContinueGame();
        // If Escape is pressed and the pause menu isn't active, then pause game and activate pause menu
        else if (Input.GetKeyDown("escape") && SceneManager.GetActiveScene().name.Equals("Main") && !_GameMenuCanvas.activeSelf) {
            _GameMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
            AudioListener.pause = true;
            gamePaused = true;
        }
    }

    // Continues the game after closing the pause menu
   public void ContinueGame()
    {
        gamePaused = false;
        Time.timeScale = 1f;
        AudioListener.pause = false;
        _GameMenuCanvas.SetActive(false);
    }

    // Used in the main menu to start a new game
    public void StartGame()
    {
        SceneManager.LoadScene("Intertitle");
    }

    // Used in the main menu to show the controls
    public void ShowControls()
    {
        _StartButton.SetActive(false);
        _ControlsButton.SetActive(false);
        _BackButton.SetActive(true);
        _ControlsPanel.SetActive(true);


    }

    // Used in the main menu to close the controls panel
    public void BackToMenu()
    {
        _StartButton.SetActive(true);
        _ControlsButton.SetActive(true);
        _BackButton.SetActive(false);
        _ControlsPanel.SetActive(false);
    }

    // Used in the pause menu as well as the success and fail scenes to go back to main menu
    public void MainMenuButton()
    {
        Time.timeScale = 1.0f;
        AudioListener.pause = false;
        audioManager.StopCurrent();
        audioManager.Stop("walk");
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
