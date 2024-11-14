using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float thrustStrength = 100f;
    //[SerializeField] float rotationStrength = 100f;
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
        Debug.Log(rotationInput);
    }
}
