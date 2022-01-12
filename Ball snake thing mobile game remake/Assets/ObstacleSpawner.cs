using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;

    private void Start()
    {
        InvokeRepeating("SpawnObstacle", 3, 3);
    }

    void SpawnObstacle()
    {
        Instantiate(obstacles[Random.Range(0, obstacles.Length)], transform.position, Quaternion.identity);
    }
}
