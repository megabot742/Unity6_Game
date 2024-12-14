using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crossHair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100f;
    bool isFiring = false;
    void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLaser();
    }
    void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }
    void ProcessFiring()
    {
        foreach(GameObject item in lasers)
        {
            var emmissionModule = item.GetComponent<ParticleSystem>().emission;
            emmissionModule.enabled = isFiring;
        }
    }
    void MoveCrosshair()
    {
        crossHair.position = Input.mousePosition;
    }
    void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }
    void AimLaser()
    {
        foreach(GameObject laser in lasers)
        {
            Vector3 fireDirection = targetPoint.position - transform.position; //ship tranform position
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationToTarget;
        }
    }
}