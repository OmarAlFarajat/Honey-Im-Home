using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class RelativeScale : MonoBehaviour
{
    GameObject origin;

    [Range(0.01f, 1.0f)]
    [SerializeField] private float _relativeScale = 0.5f;

    void Start()
    {
        origin = GameObject.Find("start0");
    }

    // Objects will scale as they move down on the screen to give the appearance that they are getting closer as the player moves forward
    void Update()
    {
        float scaleFactor = _relativeScale*Mathf.Abs(transform.position.y -  origin.transform.position.y) / ((origin.transform.position.y + Camera.main.orthographicSize));
        transform.localScale = new Vector2(scaleFactor, scaleFactor);
    }


}
