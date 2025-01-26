using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed= 8f;
    [SerializeField] float xClamp = 3f;
    [SerializeField] float zClamp = 2f;
    Rigidbody rb;
    Vector2 movement;
    void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate() 
    {
        HandleMovement();
    }
    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    } 
    void HandleMovement()
    {
        Vector3 currentPostion = rb.position;
        Vector3 moveDirection = new Vector3(movement.x, 0f, movement.y);
        Vector3 newPostion = currentPostion + moveDirection * (moveSpeed * Time.fixedDeltaTime);

        newPostion.x = Mathf.Clamp(newPostion.x, -xClamp, xClamp);
        newPostion.z = Mathf.Clamp(newPostion.z, -zClamp, zClamp);

        rb.MovePosition(newPostion);       
    }

        
}
