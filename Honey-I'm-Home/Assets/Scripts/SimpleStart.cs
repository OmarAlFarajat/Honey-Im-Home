using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SimpleStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        switch (SceneManager.GetActiveScene().name) {
            case "Intro":
                FindObjectOfType<AudioManager>().Play("intro");
                break;
            case "Fail":
                FindObjectOfType<AudioManager>().Play("fail");
                break;
            case "Succeed":
                FindObjectOfType<AudioManager>().Play("succeed");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "Intro":
                    FindObjectOfType<AudioManager>().Stop("intro");
                    break;
                case "Fail":
                    FindObjectOfType<AudioManager>().Stop("fail");
                    break;
                case "Succeed":
                    FindObjectOfType<AudioManager>().Stop("succeed");
                    break;
            }
            SceneManager.LoadScene("Main");
        }
    }
}
