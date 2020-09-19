using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputHandler : MonoBehaviour
{
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        int inputHandler = FindObjectsOfType<InputHandler>().Length;
        if (inputHandler != 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        SkipOrStart();
        AnytimeQuit();
    }
    private void SkipOrStart()
    {
        if (Input.GetKeyDown("space"))
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "Menu":
                    // Menu music continues through to intertitle
                    SceneManager.LoadScene("Intertitle");
                    break;
                case "Intertitle":
                    audioManager.StopCurrent();
                    SceneManager.LoadScene("Main");
                    break;
                case "Fail":
                    audioManager.StopCurrent();
                    SceneManager.LoadScene("Menu");
                    break;
                case "Succeed":
                    audioManager.StopCurrent();
                    SceneManager.LoadScene("Menu");
                    break;
            }

        }
    }

    private void AnytimeQuit()
    {
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }
}
