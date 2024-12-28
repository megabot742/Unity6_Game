using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField] float timeReload = 2f;
    public void ReloadLevel()
    {
        StartCoroutine(ReloadLevelRoutine());
    }
    IEnumerator ReloadLevelRoutine()
    {
        yield return new WaitForSeconds(timeReload);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
