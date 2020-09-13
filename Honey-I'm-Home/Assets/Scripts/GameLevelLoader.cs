using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLevelLoader : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(loadGame());
    }

    IEnumerator loadGame()
    {
        yield return new WaitForSeconds(18);
        FindObjectOfType<AudioManager>().Stop("intro");
        SceneManager.LoadScene("Main");
    }
}
