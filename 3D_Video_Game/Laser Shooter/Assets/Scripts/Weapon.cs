using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //[SerializeField] float maxDistance = 20f;
    
    [SerializeField] Animator animator;
    [SerializeField] ParticleSystem muzzleFlashFX;
    [SerializeField] int hitDamage = 1;
    [SerializeField] GameObject hitFXPrefabs;
    StarterAssetsInputs starterAssetsInputs;
    const string SHOOT_STRING = "Shoot";
    private void Awake() {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    } 
    void Update()
    {
        HandleShoot();
    }
    void HandleShoot()
    {
        if(!starterAssetsInputs.shoot) {return;}
        muzzleFlashFX.Play(); //VFX gun
        animator.Play(SHOOT_STRING, 0, 0f); //Animation gun
        starterAssetsInputs.ShootInput(false); //reload status 
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward,out hit, Mathf.Infinity))
        {
            Instantiate(hitFXPrefabs, hit.point, Quaternion.identity);
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(hitDamage);
        }
    }
}
