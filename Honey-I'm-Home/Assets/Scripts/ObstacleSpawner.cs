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

    // On every update, objects are spawned at random intervals of time, but the time counter only counts while the player is moving forward
    void Update()
    {
        if (Input.GetAxisRaw("Vertical") > 0 && Time.timeSinceLevelLoad > nextActionTime)
        {
            nextActionTime = Time.timeSinceLevelLoad + period + Random.Range(low_interval, high_interval);
            SpawnRandom();
        }

    }

    // Spawns a random number (1 to int max_objects) of obstacles in one of 9 positions
    void SpawnRandom()
    {
        int numObjects = Random.Range(1, max_objects);
        for (int i = 0; i < numObjects; i++)
        {
            int position = Random.Range(0, 9);

            int obstacleIndex = Random.Range(0, obstacles.Count);

            ObstacleMove obs = Instantiate(obstacles[obstacleIndex].GetComponent<ObstacleMove>(), GameObject.Find("start" + position).transform.position, Quaternion.identity);
            obs.transform.localScale = new Vector2();
            // The obstacle is given one of 9 vector paths moving along the road corresponding to the vanishing point
            obs.moveDir = GameObject.Find("end" + position).transform.position - GameObject.Find("start" + position).transform.position;
            obs.moveDir.Normalize();
        }
    }
}
