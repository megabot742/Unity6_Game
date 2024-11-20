using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] AudioClip successSFX;
    [SerializeField] AudioClip crashSFX;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;

    AudioSource audioSource;
    bool isControllable = true;
    bool isCollidable = true;
    void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update() {
        RespondToDebugKey();    
    }
    void RespondToDebugKey()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if(Input.GetKeyDown(KeyCode.C))
        {
            isCollidable = !isCollidable;
            Debug.Log("TURN OFF COLLISION");
        }
    }
    void OnCollisionEnter(Collision other) 
    {
        if(!isControllable || !isCollidable) {return;}
        switch (other.gameObject.tag)
        {
            case "Fuel":
                Debug.Log("Get Fule");
                break;
            case "Friendly":
                Debug.Log("Ready to fly");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();            
                break;
        }
    }
    private void StartSuccessSequence()
    {
        isControllable = false;
        audioSource.Stop(); // stop audio before success
        audioSource.PlayOneShot(successSFX);
        successParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }
    void StartCrashSequence()
    {
        isControllable = false;
        audioSource.Stop(); // stop audio before crash
        audioSource.PlayOneShot(crashSFX);
        crashParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
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
