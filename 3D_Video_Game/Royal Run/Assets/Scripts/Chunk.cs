using System.Collections;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] float[] lanes = {-2.5f,0f,2.5f};
    void Start()
    {
        SpawnFence();
    }
    void SpawnFence()
    {
        int randomLaneIndex = Random.Range(0,lanes.Length);
        Vector3 spawnPosition = new Vector3(lanes[randomLaneIndex],transform.position.y,transform.position.z);
        Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);
    }
}
