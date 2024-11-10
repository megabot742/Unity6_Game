using UnityEngine;

public class TriggerProjectile : MonoBehaviour
{
    [SerializeField] GameObject projectTile;
    [SerializeField] GameObject projectTile1;
    [SerializeField] GameObject projectTile2;
    [SerializeField] GameObject projectTile3;
    [SerializeField] GameObject projectTile4;
    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            projectTile.SetActive(true);
            projectTile1.SetActive(true);
            projectTile2.SetActive(true);
            projectTile3.SetActive(true);
            projectTile4.SetActive(true);
            Destroy(gameObject);
        }    
    }

}
