using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //[SerializeField] float maxDistance = 20f;
    // Update is called once per frame
    [SerializeField] int hitDamage = 1;
    StarterAssetsInputs starterAssetsInputs;
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
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward,out hit, Mathf.Infinity))
        {
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(hitDamage);
            starterAssetsInputs.ShootInput(false);
        }
    }
}
