using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem destroyVFX;
    GameSceneManager gameSceneManager;
    private void Start() 
    {
        gameSceneManager = FindFirstObjectByType<GameSceneManager>();;
    }
    private void OnTriggerEnter(Collider other) 
    {
        gameSceneManager.ReloadLevel();
        //Debug.Log("Hit" + other.name );
        Instantiate(destroyVFX,transform.position, Quaternion.identity); // Quaternion.identity = default rotations
        Destroy(gameObject);
    }
}
