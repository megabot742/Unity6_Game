using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem destroyVFX;
    private void OnParticleCollision(GameObject other) 
    {
        Instantiate(destroyVFX,transform.position, Quaternion.identity); // Quaternion.identity = default rotations
        Destroy(gameObject);
    }
}
