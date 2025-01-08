using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TMP_Text scoreText;
    int totalScore = 0;
    public void IncreseScore(int scoreCoin)
    {
        if(gameManager.GameOver == true) return;
        totalScore += scoreCoin;
        scoreText.text = "Score: " + totalScore.ToString();
    }
}
