using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float thrustStrength = 100f;
    [SerializeField] float rotationStrength = 100f;
    Rigidbody rb;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();    
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
            rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
        }
    }
    void ProcessRotaion()
    {
        float rotationInput = rotation.ReadValue<float>();
        if(rotationInput < 0)
        {
            AppplyRotation(rotationStrength);
        }
        else if(rotationInput > 0)
        {
            AppplyRotation(-rotationStrength);
        }
    }

    private void AppplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }
}
