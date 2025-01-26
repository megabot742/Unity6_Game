using UnityEngine;

public class ObstacleDestroy : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        Destroy(other.gameObject);
    }
}
