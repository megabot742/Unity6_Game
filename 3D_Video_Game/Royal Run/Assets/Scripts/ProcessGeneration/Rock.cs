using Unity.Cinemachine;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] AudioSource smashAudioSource;
    [SerializeField] ParticleSystem collisionParticleSystem;
    [SerializeField] float shakeModifer = 10f;
    [SerializeField] float collisionCoolDown = 1f;
    float collisionTimer = 1f;
    CinemachineImpulseSource cinemachineImpulseSource;
    void Awake()
    {
        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
    }
    void Update()
    {
        collisionTimer += Time.deltaTime;
    }
    void OnCollisionEnter(Collision other)
    {
        if(collisionTimer < collisionCoolDown) return;
        FireImpule();
        CollisionFX(other);
        collisionTimer = 0; //reset cooldown
    }

    void FireImpule()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float shakeIntensity = (1f / distance) * shakeModifer;
        shakeIntensity = Mathf.Min(shakeIntensity, 1f);
        cinemachineImpulseSource.GenerateImpulse(shakeIntensity);
    }
    void CollisionFX(Collision other)
    {
        ContactPoint contactPoint = other.contacts[0]; // set position
        collisionParticleSystem.transform.position = contactPoint.point;
        collisionParticleSystem.Play();
        smashAudioSource.Play();   
    }
}
