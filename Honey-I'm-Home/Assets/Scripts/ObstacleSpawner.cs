using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    private float nextActionTime = 0.0f;
    private float period = 0.75f;

    [Range(0.5f, 1.5f)]
    public float low_interval = 0.75f;

    [Range(1.6f, 3.0f)]
    public float high_interval = 1.5f;

    [Range(2, 9)]
    public int max_objects = 9; 

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
        if (Input.GetAxisRaw("Vertical") > 0 && Time.timeSinceLevelLoad > nextActionTime)
        {
            nextActionTime = Time.timeSinceLevelLoad + period + Random.Range(low_interval, high_interval);
            SpawnRandom();
        }

    }

    void SpawnRandom()
    {
        int numObjects = Random.Range(1, max_objects);
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
