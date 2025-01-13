using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] CanvasGroup optionPanel;
    public void PlayGame()
    {
        SceneManager.LoadScene("MainLevel");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
