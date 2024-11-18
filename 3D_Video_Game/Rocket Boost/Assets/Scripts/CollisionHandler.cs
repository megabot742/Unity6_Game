using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        switch (other.gameObject.tag)
        {
            case "Fuel":
                Debug.Log("Get Fule");
                break;
            case "Friendly":
                Debug.Log("Ready to fly");
                break;
            case "Finish":
                Debug.Log("Landing");
                LoadNextLevel();
                break;
            default:
                ReloadLevel();
                break;
        }
    }
    void LoadNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;
        if(nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }
        SceneManager.LoadScene(nextScene);
    }
    void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex; // get current scene when playing
        SceneManager.LoadScene(currentScene); // reload current scene
    }
    
}
