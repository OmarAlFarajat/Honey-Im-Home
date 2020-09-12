using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class RelativeScale : MonoBehaviour
{
    GameObject origin;

    // Start is called before the first frame update
    void Start()
    {
        origin = GameObject.Find("start0");
    }

    // Update is called once per frame
    void Update()
    {
        float scaleFactor = 2f*Mathf.Abs(transform.position.y -  origin.transform.position.y) / ((origin.transform.position.y + Camera.main.orthographicSize));
        transform.localScale = new Vector2(scaleFactor, scaleFactor);
    }


}
