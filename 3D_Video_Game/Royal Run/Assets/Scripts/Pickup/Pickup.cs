using UnityEngine;

public class Pickup : MonoBehaviour
{
    const string playerString = "Player";
    void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag(playerString))
        {
            Debug.Log(other.gameObject.name);
            Destroy(gameObject);
        }
    }
}
