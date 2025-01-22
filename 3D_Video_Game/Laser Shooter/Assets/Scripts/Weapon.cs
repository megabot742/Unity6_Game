using UnityEngine;

public class Weapon : MonoBehaviour
{
    //[SerializeField] float maxDistance = 20f;
    
    [SerializeField] ParticleSystem muzzleFlashFX;
    
    public void Shoot(WeaponSO weaponSO)
    {
        muzzleFlashFX.Play(); //VFX gun
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward,out hit, Mathf.Infinity))
        {
            Instantiate(weaponSO.HitFXPrefabs, hit.point, Quaternion.identity);
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(weaponSO.Damage);
        }
    }
}
