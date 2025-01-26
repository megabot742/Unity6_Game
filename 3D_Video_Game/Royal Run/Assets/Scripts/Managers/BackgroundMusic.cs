using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    void Start()
    {
        int numOfMusicPlayers = FindObjectsByType<BackgroundMusic>(FindObjectsSortMode.None).Length;
        if(numOfMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
