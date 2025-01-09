using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] float startTime = 30f;
    float timeLeft;
    bool gameOver; // false
    public bool GameOver => gameOver;
    // public bool GameOver
    // {
    //     get{return gameOver;}
    //     set{gameOver = value;}
    // }
    //public bool GameOver { get {return gameOver;} }
    //public bool GameOver { get; private set;}
    void Start() 
    {
        timeLeft = startTime;
    }
    void Update() 
    {
        DecreaseTime();
    }
    void DecreaseTime()
    {
        if(gameOver) return;
        timeLeft -= Time.deltaTime;
        timeText.text = "Time: " + timeLeft.ToString("F1");
        if(timeLeft < Mathf.Epsilon)
        {
            PlayerGameOver();
        }
    }
    void PlayerGameOver()
    {
        gameOver = true;
        playerController.enabled = false;
        gameOverText.SetActive(true);
        Time.timeScale = 0.1f;
    }
    public void IncreaseTime(float bonusTime)
    {
        if(gameOver) return;
        timeLeft += bonusTime;
    }
}
