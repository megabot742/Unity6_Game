using System.Collections;
using StarterAssets;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject robotPrefabs;
    [SerializeField] float spawnTime = 5f;
    [SerializeField] Transform spawnPoint;
    PlayerHealth playerHealth;
    void Start()
    {
        playerHealth = FindFirstObjectByType<PlayerHealth>();
        StartCoroutine(SpawnRobot());
    }
    // Update is called once per frame
    IEnumerator SpawnRobot()
    {
        while(playerHealth)
        {
            Instantiate(robotPrefabs, spawnPoint.position, transform.rotation);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
