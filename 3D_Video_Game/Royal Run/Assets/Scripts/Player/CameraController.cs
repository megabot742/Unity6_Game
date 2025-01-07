using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] ParticleSystem speedUpVFX;
    [SerializeField] float minFOV = 50f;
    [SerializeField] float maxFOV = 80f;
    [SerializeField] float zoomDuration = 1f;
    [SerializeField] float zoomSpeedModifer = 5f;
    CinemachineCamera cinemachineCamera;
    void Awake()
    {
        cinemachineCamera = GetComponent<CinemachineCamera>();
    }
    public void ChangeCameraFOV(float speedAmount)
    {
        StopAllCoroutines(); //lock key
        StartCoroutine(ChaneFOVRoutine(speedAmount));
        if(speedAmount > 0)
        {
            speedUpVFX.Play();
        }
    }
    IEnumerator ChaneFOVRoutine(float speedAmount)
    {
        float startFOV = cinemachineCamera.Lens.FieldOfView;
        float targetFOV = Mathf.Clamp(startFOV + speedAmount * zoomSpeedModifer, minFOV, maxFOV);

        float elapsedTime = 0f;
        while(elapsedTime < zoomDuration)
        {
            float t = elapsedTime / zoomDuration; //0% -> 100%
            elapsedTime += Time.deltaTime;

            cinemachineCamera.Lens.FieldOfView = Mathf.Lerp(startFOV, targetFOV, t);
            yield return null;
        }

        cinemachineCamera.Lens.FieldOfView = targetFOV;
    }
}
