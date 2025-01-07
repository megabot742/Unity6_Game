using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    int totalScore = 0;
    public void IncreseScore(int scoreCoin)
    {
        totalScore += scoreCoin;
        scoreText.text = "Score: " + totalScore.ToString();
    }
}
