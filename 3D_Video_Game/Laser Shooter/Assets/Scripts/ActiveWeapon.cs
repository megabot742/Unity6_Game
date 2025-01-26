using System.Collections;
using UnityEngine;
using StarterAssets;
using Cinemachine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] CinemachineVirtualCamera playerFollowCamera;
    [SerializeField] GameObject zoomVignette;
    Animator animator;
    StarterAssetsInputs starterAssetsInputs;
    FirstPersonController firstPersonController;
    Weapon currentWeapon;
    const string SHOOT_STRING = "Shoot";
    float timeCoolDownShoot = 0;
    float defaultFOV;
    float defaultRotationSpeed;
    void Awake() 
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        firstPersonController = GetComponentInParent<FirstPersonController>();
        animator = GetComponent<Animator>();
        defaultFOV = playerFollowCamera.m_Lens.FieldOfView;
        defaultRotationSpeed = firstPersonController.RotationSpeed;
    }
    void Start() 
    {
        currentWeapon = GetComponentInChildren<Weapon>();
    }
    void Update()
    {
        
        HandleShoot();
        HandleZoom();
    }
    public void SwitchWeapon(WeaponSO weaponSO)
    {
        if(currentWeapon)
        {
            Destroy(currentWeapon.gameObject);
        }
        Weapon newWeapon = Instantiate(weaponSO.weaponPrefab, transform).GetComponent<Weapon>();
        currentWeapon = newWeapon;
        this.weaponSO = weaponSO;
    }
    void HandleShoot()
    {
        timeCoolDownShoot += Time.deltaTime;
        if(!starterAssetsInputs.shoot) {return;}
        if(timeCoolDownShoot >= weaponSO.FireRate)
        {
            currentWeapon.Shoot(weaponSO);
            animator.Play(SHOOT_STRING, 0, 0f); //Animation gun
            timeCoolDownShoot = 0;
        }
        if(!weaponSO.IsAutomatic)
        {
            starterAssetsInputs.ShootInput(false); //reload status 
        }
    }
    void HandleZoom()
    {
        if(!weaponSO.CanZoom) {return;}
        if(starterAssetsInputs.zoom)
        {
            playerFollowCamera.m_Lens.FieldOfView = weaponSO.ZoomAmount;
            zoomVignette.SetActive(true);
            firstPersonController.SetRotationSpeed(weaponSO.ZoomRotationSpeed);
        }
        else
        {
            playerFollowCamera.m_Lens.FieldOfView = defaultFOV;
            zoomVignette.SetActive(false);
            firstPersonController.SetRotationSpeed(defaultRotationSpeed);
        }
    }
}
