using UnityEngine;
using StarterAssets;
using Unity.VisualScripting;
using Unity.Mathematics;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    Animator animator;
    StarterAssetsInputs starterAssetsInputs;
    Weapon currentWeapon;
    const string SHOOT_STRING = "Shoot";
    float timeCoolDownShoot = 0;
    void Awake() 
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>(); 
        animator = GetComponent<Animator>();
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
            Debug.Log("Zoom in");
        }
        else
        {
            Debug.Log("Zoom out");
        }
    }
}
