using UnityEngine;
using StarterAssets;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    Animator animator;
    StarterAssetsInputs starterAssetsInputs;
    Weapon weapon;
    const string SHOOT_STRING = "Shoot";
    float timeCoolDownShoot = 0;
    void Awake() 
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>(); 
        animator = GetComponent<Animator>();
    }
    void Start() 
    {
        weapon = GetComponentInChildren<Weapon>();
    }
    void Update()
    {
        timeCoolDownShoot += Time.deltaTime;
        HandleShoot();
    }
    void HandleShoot()
    {
        if(!starterAssetsInputs.shoot) {return;}
        if(timeCoolDownShoot >= weaponSO.FireRate)
        {
            weapon.Shoot(weaponSO);
            animator.Play(SHOOT_STRING, 0, 0f); //Animation gun
            timeCoolDownShoot = 0;
        }
        starterAssetsInputs.ShootInput(false); //reload status 
    }
}
