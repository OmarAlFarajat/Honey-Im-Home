using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    private void Start()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Fail":
                FindObjectOfType<AudioManager>().Play("fail");
                break;
            case "Succeed":
                FindObjectOfType<AudioManager>().Play("succeed");
                break;
        }
        StartCoroutine(restart());
    }

    IEnumerator restart()
    {
        yield return new WaitForSeconds(8);
        switch (SceneManager.GetActiveScene().name)
        {
            case "Fail":
                FindObjectOfType<AudioManager>().Stop("fail");
                break;
            case "Succeed":
                FindObjectOfType<AudioManager>().Stop("succeed");
                break;
        }
        SceneManager.LoadScene("Menu");
    }
}
