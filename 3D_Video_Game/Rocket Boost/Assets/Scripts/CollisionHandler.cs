using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        switch (other.gameObject.tag)
        {
            case "Finish":
                Debug.Log("Landing");
                break;
            case "Fuel":
                Debug.Log("Get Fule");
                break;
            case "Friendly":
                Debug.Log("Ready to fly");
                break;
            default:
                Debug.Log("You crash");
                break;
        }
    }
}
