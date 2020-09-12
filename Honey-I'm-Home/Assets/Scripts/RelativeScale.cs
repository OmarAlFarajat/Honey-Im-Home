using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class RelativeScale : MonoBehaviour
{
    GameObject origin;
    GameObject end;

    Vector2 moveDir;

    // Start is called before the first frame update
    void Start()
    {
        origin = GameObject.Find("origin");
        transform.position = new Vector2(transform.position.x, origin.transform.position.y);


        switch (Random.Range(0,5)) {
            case 0:
                end = GameObject.Find("end0");
                break;
            case 1:
                end = GameObject.Find("end1");
                break;
            case 2:
                end = GameObject.Find("end2");
                break;
            case 3:
                end = GameObject.Find("end3");
                break;
            case 4:
                end = GameObject.Find("end4");
                break;
        }

        if (end != null)
        {
            moveDir = end.transform.position - origin.transform.position;
            moveDir.Normalize();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float scaleFactor = Mathf.Abs(transform.position.y -  origin.transform.position.y) / ((origin.transform.position.y + Camera.main.orthographicSize)*0.75f);
        transform.localScale = new Vector2(scaleFactor, scaleFactor);
        transform.position += new Vector3(moveDir.x, moveDir.y, 0).normalized *0.5f* Time.deltaTime;
    }


}
