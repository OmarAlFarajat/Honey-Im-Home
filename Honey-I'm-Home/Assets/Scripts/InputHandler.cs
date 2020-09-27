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

    private AudioManager audioManager;

    // Start is called before the first frame update
    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        //int inputHandler = FindObjectsOfType<InputHandler>().Length;
        //if (inputHandler != 1)
        //    Destroy(gameObject);
        //else
        //    DontDestroyOnLoad(gameObject);

       _StartButton = GameObject.Find("StartButton");
        _ControlsButton = GameObject.Find("ControlsButton");
        _BackButton = GameObject.Find("BackButton");
        _ControlsPanel = GameObject.Find("ControlsPanel");

        if(_ControlsPanel)
        _ControlsPanel.SetActive(false);
        
        if(_BackButton)
        _BackButton.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        Skip();
        // Disabled ability to press escape to terminate game with Escape key. 
        //AnytimeQuit();
    }

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

    // Not used for WebGL build
    private void AnytimeQuit()
    {
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Intertitle");
    }

    public void ShowControls()
    {
        _StartButton.SetActive(false);
        _ControlsButton.SetActive(false);
        _BackButton.SetActive(true);
        _ControlsPanel.SetActive(true);


    }
    public void BackToMenu()
    {
        _StartButton.SetActive(true);
        _ControlsButton.SetActive(true);
        _BackButton.SetActive(false);
        _ControlsPanel.SetActive(false);
    }

    public void MainMenuButton()
    {
        audioManager.StopCurrent();
        SceneManager.LoadScene("Menu");
    }
}
