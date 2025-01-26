using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float thrustStrength = 100f;
    [SerializeField] float rotationStrength = 100f;
    [SerializeField] AudioClip mainEngineSFX;

    [SerializeField] ParticleSystem mainEngineVFX;
    [SerializeField] ParticleSystem leftBoosterVFX;
    [SerializeField] ParticleSystem rightBoosterVFX;

    Rigidbody rb;
    AudioSource audioSource;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

    }
    private void OnEnable() 
    {
        thrust.Enable(); 
        rotation.Enable();
    }

    private void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotaion();
    }

    void ProcessThrust()
    {
        if (thrust.IsPressed())
        {
            StartThrust();
        }
        else
        {
            StopThrust();
        }
    }
    private void StartThrust()
    {
        rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngineSFX);
        }
        if (!mainEngineVFX.isPlaying)
        {
            mainEngineVFX.Play();
        }
    }
    private void StopThrust()
    {
        audioSource.Stop();
        mainEngineVFX.Stop();
    }

    void ProcessRotaion()
    {
        float rotationInput = rotation.ReadValue<float>();
        if(rotationInput < 0)
        {
            RotateRight();
        }
        else if(rotationInput > 0)
        {
            RorateLeft();
        }
        else
        {
            StopRotate();
        }
    }
    private void AppplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }
    private void RotateRight()
    {
        AppplyRotation(rotationStrength);
        if (!rightBoosterVFX.isPlaying)
        {
            rightBoosterVFX.Play();
            leftBoosterVFX.Stop();
        }
    }
    private void RorateLeft()
    {
        AppplyRotation(-rotationStrength);
        if (!leftBoosterVFX.isPlaying)
        {
            leftBoosterVFX.Play();
            rightBoosterVFX.Stop();
        }
    }
    private void StopRotate()
    {
        rightBoosterVFX.Stop();
        leftBoosterVFX.Stop();
    }
    
}
