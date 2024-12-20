using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    int score = 0;
    [SerializeField] TMP_Text scoreBoardText;
    
    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreBoardText.text = "Score: " + score.ToString();
    }
}
