using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public float period = 0.0f;
    public float interval = 1.0f;

    public List<GameObject> obstacles = new List<GameObject>();

    private void Awake()
    {
        foreach (GameObject obstacle in obstacles)
        {
            if (obstacle.GetComponent<ObstacleMove>() == null)
            {
                obstacle.AddComponent<ObstacleMove>();
            }
        }
    }

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

            int obstacleIndex = Random.Range(0, obstacles.Count);

            ObstacleMove obs = Instantiate(obstacles[obstacleIndex].GetComponent<ObstacleMove>(), GameObject.Find("start" + position).transform.position, Quaternion.identity);
            obs.transform.localScale = new Vector2();
            obs.moveDir = GameObject.Find("end" + position).transform.position - GameObject.Find("start" + position).transform.position;
            obs.moveDir.Normalize();
        }
    }
}
