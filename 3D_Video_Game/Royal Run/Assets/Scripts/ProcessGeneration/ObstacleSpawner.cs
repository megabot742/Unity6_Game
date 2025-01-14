using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] float obstacleSpawnTime = 3f;
    [SerializeField] Transform obstacleParent;
    [SerializeField] float spawnWidth = 4f;
    [SerializeField] bool isSpawn = true;
    const float minObstacleSpawnTime = 0.5f;
    void Start()
    {
       StartCoroutine(SpawnObstacles());
    }
    public void DecreaseObstacleSpawnTime(float amount)
    {
        obstacleSpawnTime -= amount;
        if(obstacleSpawnTime <= minObstacleSpawnTime) obstacleSpawnTime = minObstacleSpawnTime;
    }
    IEnumerator SpawnObstacles()
    {
        while (isSpawn)
        { 
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnWidth, spawnWidth),transform.position.y,transform.position.z);
            Instantiate(obstaclePrefab, spawnPosition, Random.rotation, obstacleParent);
            yield return new WaitForSeconds(obstacleSpawnTime);
        }
        
    }
}
