using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class RelativeScale : MonoBehaviour
{
    GameObject origin;

    [Range(0.01f, 1.0f)]
    [SerializeField] private float _relativeScale = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        origin = GameObject.Find("start0");
    }

    // Update is called once per frame
    void Update()
    {
        float scaleFactor = _relativeScale*Mathf.Abs(transform.position.y -  origin.transform.position.y) / ((origin.transform.position.y + Camera.main.orthographicSize));
        transform.localScale = new Vector2(scaleFactor, scaleFactor);
    }


}
