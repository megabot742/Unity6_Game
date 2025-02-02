using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform turretHead;
    [SerializeField] Transform playerTargetPoint;
    [SerializeField] Transform projectileSpawnPoint;
    [SerializeField] float fireRate = 5f;
    [SerializeField] int damageProjectile = 2;
    PlayerHealth playerHealth;
    void Start() 
    {
        playerHealth = FindFirstObjectByType<PlayerHealth>();
        StartCoroutine(FireRoutine());
    }
    void Update() 
    {
        turretHead.LookAt(playerTargetPoint);
    }
    IEnumerator FireRoutine()
    {
        while(playerHealth)
        {
            Projectile newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity).GetComponent<Projectile>();
            newProjectile.transform.LookAt(playerTargetPoint);
            newProjectile.Init(damageProjectile);
            yield return new WaitForSeconds(fireRate);
        }
    }

}
