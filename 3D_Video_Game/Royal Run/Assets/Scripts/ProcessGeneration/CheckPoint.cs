using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] float bonusTime  = 5f;
    [SerializeField] float obstacleDecreaseTimeAmount = 0.1f;
    const string stringPlayer = "Player";
    GameManager gameManager;
    ObstacleSpawner obstacleSpawner;
    private void Start() 
    {
        gameManager = FindFirstObjectByType<GameManager>();
        obstacleSpawner = FindFirstObjectByType<ObstacleSpawner>();
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag(stringPlayer))
        {
            gameManager.IncreaseTime(bonusTime);   
            obstacleSpawner.DecreaseObstacleSpawnTime(obstacleDecreaseTimeAmount);
        }
    }
}
