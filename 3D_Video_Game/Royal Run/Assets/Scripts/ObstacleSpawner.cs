using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] float timeSpawn = 2f;
     int obstaclesSpawned = 0;
    void Start()
    {
       StartCoroutine(SpawnObstacles());
    }
    IEnumerator SpawnObstacles()
    {
        while (obstaclesSpawned < 10)
        {
            Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
            obstaclesSpawned++;
            yield return new WaitForSeconds(timeSpawn);
        }
        
    }
}
