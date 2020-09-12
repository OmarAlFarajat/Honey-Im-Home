using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{

    public Vector2 moveDir;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Vertical") > 0)
            transform.position += new Vector3(moveDir.x, moveDir.y, 0)* Time.deltaTime;

        if (transform.position.y < -Camera.main.orthographicSize)
            Destroy(gameObject);
    }
}
