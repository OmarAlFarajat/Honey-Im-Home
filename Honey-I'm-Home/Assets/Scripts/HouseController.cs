using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseController : MonoBehaviour
{
    // Times per second that house position and scale are updated
    public float DRAW_UPDATE = 4.0f;

    // Time to get to the house in seconds
    public float HOUSE_TIME = 180;

    private float _scale_accrued = 0.00f;
    private float SCALE_SEG;

    private float _dist_accrued;
    private float DIST_SEG = 0.025f;

    private float nextActionTime = 0.0f;
    private float PERIOD = 1f;

    private const float Y_TARGET = -1.78f;
    private float HALFWAY;
    private bool isHalfway = false;
    private GameObject _halfwayText;

    private AudioManager audioManager;

    // Start is called before the first frame update
    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        SCALE_SEG = transform.localScale.x / HOUSE_TIME / DRAW_UPDATE;
        transform.localScale = new Vector2(0.0f, 0.0f);
        transform.position = new Vector2(0, Y_TARGET - DIST_SEG * HOUSE_TIME);
        _dist_accrued = transform.position.y;
        HALFWAY = (transform.position.y - Y_TARGET) / 1.75f + Y_TARGET;
        Debug.Log("HALFWAY: " + HALFWAY);
        DIST_SEG /= DRAW_UPDATE;
        PERIOD /= DRAW_UPDATE;
        _halfwayText = GameObject.Find("HalfwayCanvas");
        _halfwayText.SetActive(false);
    }

    void Update()
    {
        scaleHouseOverTime();
    }

    // Scales and translates the house over time only while the player is moving forward, to give the impression it is being approached
    // Once the house is at a certain position (Y_TARGET), it will trigger a game win event
    void scaleHouseOverTime()
    {
        if (Input.GetAxisRaw("Vertical") > 0 && Time.timeSinceLevelLoad > nextActionTime)
        {
            nextActionTime = Time.timeSinceLevelLoad + PERIOD;
            _scale_accrued += SCALE_SEG;
            _dist_accrued += DIST_SEG;
            transform.position = new Vector2(0f, _dist_accrued);
            transform.localScale = new Vector2(Mathf.Clamp(_scale_accrued, 0f, 1.01f), Mathf.Clamp(_scale_accrued, 0f, 1.01f));

            if (_dist_accrued >= HALFWAY && !isHalfway)
            {
                StartCoroutine(DisplayHalfway());
            }

            if (_dist_accrued >= Y_TARGET)
            {
                audioManager.StopCurrent();
                audioManager.Stop("walk");
                SceneManager.LoadScene("Succeed");
            }
        }
    }

    // Displays a message to the player when they are roughly halfway to the house
    IEnumerator DisplayHalfway()
    {
        isHalfway = true;
        _halfwayText.SetActive(true);
        audioManager.Play("Halfway");
        yield return new WaitForSeconds(10);
        _halfwayText.SetActive(false);
    }

}
