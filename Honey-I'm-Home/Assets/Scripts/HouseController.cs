using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseController : MonoBehaviour
{
    public const float SCALE_SEG = 0.0025f;
    public const float DIST_SEG = 0.027f;
    public float _scale_accrued = 0.15f;
    public float _dist_accrued = -6.63f; 

    public float nextActionTime = 0.0f;
    private const float PERIOD = 1f;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector2(0.15f, 0.15f);
        transform.position = new Vector2(0, -6.63f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scaleHouseOverTime();
    }

    void scaleHouseOverTime()
    {
        if (Input.GetAxisRaw("Vertical") > 0 && Time.timeSinceLevelLoad > nextActionTime)
        {
            nextActionTime += PERIOD;
            _scale_accrued += SCALE_SEG;
            _dist_accrued += DIST_SEG;
            transform.position = new Vector2(0f, _dist_accrued);
            transform.localScale = new Vector2(Mathf.Clamp(_scale_accrued, 0f, 1.01f), Mathf.Clamp(_scale_accrued, 0f, 1.01f));

            if (_dist_accrued >= -1.78f)
            {
                transform.position = new Vector2(0, -6.63f);
                transform.localScale = new Vector2(0.15f, 0.15f);
                _dist_accrued = -6.63f;
                _scale_accrued = 0.15f;
                nextActionTime = 0.0f;
                FindObjectOfType<AudioManager>().StopCurrent();
                SceneManager.LoadScene("Succeed");
            }
        }
    }

}
