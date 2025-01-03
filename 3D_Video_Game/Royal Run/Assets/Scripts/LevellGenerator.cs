using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LevellGenerator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int startingChunksAmount = 12;
    [SerializeField] Transform chunkParent;
    [SerializeField] float chunkLength = 10f;
    [SerializeField] float moveSpeed = 8f;
    List<GameObject> chunks = new List<GameObject>();
    void Start()
    {
       SpawnStartingChunks();
    }
    void Update()
    {
        MoveChunks();
    }
    void SpawnStartingChunks()
    {
        for (int i = 0; i < startingChunksAmount; i++)
        {
            SpawnChunk();
        }
    }
    void SpawnChunk()
    {
        float spawnPosition = CalculateSpwanPosition();
        Vector3 chunkSpawnPos = new Vector3(transform.position.x,transform.position.y,spawnPosition);
        GameObject newChunk = Instantiate(chunkPrefab, chunkSpawnPos, Quaternion.identity, chunkParent);

        chunks.Add(newChunk);
    }
    float CalculateSpwanPosition()
    {
        float spawnPosition;
        if(chunks.Count == 0)
        {
            spawnPosition = transform.position.z;
        }
        else
        {
            spawnPosition = chunks[chunks.Count -1].transform.position.z + chunkLength; //spawn after last element in list + chunk length
        }
        return spawnPosition;
    }
    void MoveChunks()
    {
        for (int i = 0; i < chunks.Count; i++)
        {  
            GameObject chunk = chunks[i];
            chunk.transform.Translate(-Vector3.forward * (moveSpeed * Time.deltaTime));
            if(chunk.transform.position.z <= Camera.main.transform.position.z - chunkLength)
            {
                chunks.Remove(chunk);
                Destroy(chunk);
                SpawnChunk();
            }
        }  
    }
    
}
