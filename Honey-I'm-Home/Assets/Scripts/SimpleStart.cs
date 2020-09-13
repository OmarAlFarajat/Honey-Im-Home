using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SimpleStart : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("intro");
    }

    public void startGame()
    {
        SceneManager.LoadScene("Intertitle");
    }

}
