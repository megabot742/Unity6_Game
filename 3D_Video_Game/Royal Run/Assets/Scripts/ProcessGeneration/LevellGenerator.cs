using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LevellGenerator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] CameraController cameraController;
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] Transform chunkParent;
    [SerializeField] ScoreManager scoreManager;

    [Header("Level Setting")]
    [SerializeField] int startingChunksAmount = 12;
    [Tooltip("Do not change chunk length value unless chunk prefab size reflects change")]
    [SerializeField] float chunkLength = 10f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float minMoveSpeed = 6f;
    [SerializeField] float maxMoveSpeed = 20f;

    [Header("GravityZ")]
    [SerializeField] float minGravtiyZ = -20.81f;
    [SerializeField] float maxGravtiyZ = -9.81f;

    List<GameObject> chunks = new List<GameObject>();
    void Start()
    {
       SpawnStartingChunks();
    }
    void Update()
    {
        MoveChunks();
    }
    public void ChangeChunkMoveSpeed(float speedAmount)
    {
        float newMoveSpeed = moveSpeed + speedAmount;
        newMoveSpeed = Mathf.Clamp(newMoveSpeed, minMoveSpeed, maxMoveSpeed);
        if(newMoveSpeed != moveSpeed)
        {
            moveSpeed = newMoveSpeed;
            float newGravityZ = Physics.gravity.z - speedAmount;
            newGravityZ = Mathf.Clamp(newGravityZ, minGravtiyZ, maxGravtiyZ);
            Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, newGravityZ);

            cameraController.ChangeCameraFOV(speedAmount);
        }    
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
        GameObject newChunkGO = Instantiate(chunkPrefab, chunkSpawnPos, Quaternion.identity, chunkParent);

        chunks.Add(newChunkGO);
        Chunk newChunk = newChunkGO.GetComponent<Chunk>();
        newChunk.Init(this, scoreManager);
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
