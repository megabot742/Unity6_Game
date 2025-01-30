using Cinemachine;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //[SerializeField] float maxDistance = 20f;
    
    [SerializeField] ParticleSystem muzzleFlashFX;
    [SerializeField] LayerMask interactionLayer;
    
    CinemachineImpulseSource impulseSource;
    void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }
    public void Shoot(WeaponSO weaponSO)
    {
        muzzleFlashFX.Play(); //VFX gun
        impulseSource.GenerateImpulse();
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward,out hit, Mathf.Infinity, interactionLayer, QueryTriggerInteraction.Ignore))
        {
            Instantiate(weaponSO.HitFXPrefabs, hit.point, Quaternion.identity);
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(weaponSO.Damage);
        }
    }
}
