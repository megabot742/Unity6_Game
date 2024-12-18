using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem destroyVFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Hit" + other.name);
        Instantiate(destroyVFX,transform.position, Quaternion.identity); // Quaternion.identity = default rotations
        Destroy(gameObject);
    }
}
