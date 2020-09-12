using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public float period = 0.0f;
    public float interval = 1.0f;
    public ObstacleMove obstacle0;
    public ObstacleMove obstacle1;
    public ObstacleMove obstacle2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            if (period > interval)
            {
                SpawnRandom();
                period = 0;
                interval = Random.Range(0.75f, 1.5f);
            }
            period += UnityEngine.Time.deltaTime;
        }

    }

    void SpawnRandom()
    {
        int numObjects = Random.Range(1, 9);
        for (int i = 0; i < numObjects; i++)
        {
            int position = Random.Range(0, 9);

            switch (Random.Range(0, 3))
            {
                case 0:
                    ObstacleMove obs0 = Instantiate(obstacle0, GameObject.Find("start" + position).transform.position, Quaternion.identity);
                    obs0.transform.localScale = new Vector2();
                    obs0.moveDir = GameObject.Find("end" + position).transform.position - GameObject.Find("start" + position).transform.position;
                    obs0.moveDir.Normalize();
                    break;
                case 1:
                    ObstacleMove obs1 = Instantiate(obstacle1, GameObject.Find("start" + position).transform.position, Quaternion.identity);
                    obs1.transform.localScale = new Vector2();
                    obs1.moveDir = GameObject.Find("end" + position).transform.position - GameObject.Find("start" + position).transform.position;
                    obs1.moveDir.Normalize();
                    break;
                case 2:
                    ObstacleMove obs2 = Instantiate(obstacle2, GameObject.Find("start" + position).transform.position, Quaternion.identity);
                    obs2.transform.localScale = new Vector2();
                    obs2.moveDir = GameObject.Find("end" + position).transform.position - GameObject.Find("start" + position).transform.position;
                    obs2.moveDir.Normalize();
                    break;
            }

        }
    }
}
