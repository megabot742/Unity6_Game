using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovoments : MonoBehaviour
{
    [Header("Moveoment")]
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xClampRange = 35f;
    [SerializeField] float yClampRange = 35f;

    [Header("Rotation")]
    [SerializeField] float controlRollFactor = 20f;
    [SerializeField] float controlPitchFactor = 20f;
    [SerializeField] float rotationSpeed = 20f;

    Vector2 movement;
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }
    public void OnMove(InputValue value)
    {
       movement = value.Get<Vector2>();
    }
    void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);


        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);
        transform.localPosition = new Vector3(clampedXPos, clampedYPos , 0f);
    }
    void ProcessRotation()
    {
        float roll = -controlRollFactor*movement.x;
        float pitch = -controlPitchFactor*movement.y;
        Quaternion targetRotation = Quaternion.Euler(pitch, 0f, roll); //The flight direction must be opposite movement
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
