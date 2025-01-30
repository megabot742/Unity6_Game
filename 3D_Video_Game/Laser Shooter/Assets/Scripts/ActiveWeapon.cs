using System.Collections;
using UnityEngine;
using StarterAssets;
using Cinemachine;
using TMPro;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] WeaponSO startingWeaponSO;
    [SerializeField] CinemachineVirtualCamera playerFollowCamera;
    [SerializeField] Camera weaponCamera;
    [SerializeField] GameObject zoomVignette;
    [SerializeField] TMP_Text ammoText;

    WeaponSO currentWeaponSO;
    Weapon currentWeapon;
    Animator animator;
    StarterAssetsInputs starterAssetsInputs;
    FirstPersonController firstPersonController;
    const string SHOOT_STRING = "Shoot";
    float timeCoolDownShoot = 0;
    float defaultFOV;
    float defaultRotationSpeed;
    int currentAmmo;
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
        SwitchWeapon(startingWeaponSO);
    }
    void Update()
    {
        
        HandleShoot();
        HandleZoom();
    }
    public void AdjustAmmo(int amount)
    {
        currentAmmo += amount;
        if(currentAmmo > currentWeaponSO.MagazineSize) //check ammo
        {
            currentAmmo = currentWeaponSO.MagazineSize;
        }
        ammoText.text = currentAmmo.ToString("D2");
    }
    public void SwitchWeapon(WeaponSO weaponSO)
    {
        if(currentWeapon)
        {
            Destroy(currentWeapon.gameObject);
        }
        Weapon newWeapon = Instantiate(weaponSO.weaponPrefab, transform).GetComponent<Weapon>();
        currentWeapon = newWeapon;
        this.currentWeaponSO = weaponSO; //change Gun 
        AdjustAmmo(currentWeaponSO.MagazineSize); // change Ammo
    }
    void HandleShoot()
    {
        timeCoolDownShoot += Time.deltaTime;
        if(!starterAssetsInputs.shoot) {return;}
        if(timeCoolDownShoot >= currentWeaponSO.FireRate && currentAmmo > 0)
        {
            currentWeapon.Shoot(currentWeaponSO);
            animator.Play(SHOOT_STRING, 0, 0f); //Animation gun
            timeCoolDownShoot = 0;
            AdjustAmmo(-1);
        }
        if(!currentWeaponSO.IsAutomatic)
        {
            starterAssetsInputs.ShootInput(false); //reload status 
        }
    }
    void HandleZoom()
    {
        if(!currentWeaponSO.CanZoom) {return;}
        if(starterAssetsInputs.zoom)
        {
            playerFollowCamera.m_Lens.FieldOfView = currentWeaponSO.ZoomAmount;
            weaponCamera.fieldOfView = currentWeaponSO.ZoomAmount;
            zoomVignette.SetActive(true);
            firstPersonController.SetRotationSpeed(currentWeaponSO.ZoomRotationSpeed);
        }
        else
        {
            playerFollowCamera.m_Lens.FieldOfView = defaultFOV;
            weaponCamera.fieldOfView = defaultFOV;
            zoomVignette.SetActive(false);
            firstPersonController.SetRotationSpeed(defaultRotationSpeed);
        }
    }
}
