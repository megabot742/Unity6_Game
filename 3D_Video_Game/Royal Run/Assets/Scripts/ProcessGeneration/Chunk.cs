using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject applePrefab;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] float appleSpawnChance = 0.3f;
    [SerializeField] float coinSpawnChance = 0.5f;
    [SerializeField] float[] lanes = {-2.5f,0f,2.5f};
    [SerializeField] float coinSeperationLength = 2f;
    List<int> availableLanes = new List<int> {0, 1, 2};
    LevellGenerator levellGenerator;
    ScoreManager scoreManager;
    void Start()
    {
        SpawnFences();
        SpawnApple();
        SpawnCoin();
    }
    public void Init(LevellGenerator levellGenerator, ScoreManager scoreManager)
    {
        this.levellGenerator = levellGenerator;
        this.scoreManager = scoreManager;
    }
    void SpawnFences()
    {
        int fencesToSpawn = Random.Range(0, lanes.Length);
        for (int i = 0; i < fencesToSpawn; i++)
        {
            if (availableLanes.Count <= 0) break;
            int selectedLane = SelectLane();

            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);
        }
    }

    void SpawnApple()
    {
        if(Random.value > appleSpawnChance || availableLanes.Count <= 0) return;
        int selectedLane = SelectLane();

        Vector3 spawnPosition = new Vector3(lanes[selectedLane],transform.position.y,transform.position.z);
        Apple newApple = Instantiate(applePrefab, spawnPosition, Quaternion.identity, this.transform).GetComponent<Apple>();
        newApple.Init(levellGenerator);
    }
    void SpawnCoin()
    {
        if(Random.value > coinSpawnChance || availableLanes.Count <= 0) return;
        int selectedLane = SelectLane();

        int maxCoinsToSpawn = 6;
        int coinToSpawn = Random.Range(1, maxCoinsToSpawn); //1,2,3,4,5
        float topOfChunkZPos = transform.position.z + (coinSeperationLength * 2f);
        for (int i = 0; i < coinToSpawn; i++)
        {
            float spawnPosZ = topOfChunkZPos - (i * coinSeperationLength);
            Vector3 spawnPosition = new Vector3(lanes[selectedLane],transform.position.y,spawnPosZ);
            Coin newCoin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity, this.transform).GetComponent<Coin>();
            newCoin.Init(scoreManager);
        }

    }
    int SelectLane()
    {
        int randomLaneIndex = Random.Range(0, availableLanes.Count);
        int selectedLane = availableLanes[randomLaneIndex];
        availableLanes.RemoveAt(randomLaneIndex);
        return selectedLane;
    }
}
