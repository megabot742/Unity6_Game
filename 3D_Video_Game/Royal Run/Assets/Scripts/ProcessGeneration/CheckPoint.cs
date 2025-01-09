using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] float bonusTime  = 5f;
    const string stringPlayer = "Player";
    GameManager gameManager;
    private void Start() 
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag(stringPlayer))
        {
            gameManager.IncreaseTime(bonusTime);   
        }
    }
}
