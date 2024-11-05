using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) 
    {
        GetComponent<MeshRenderer>().material.color = Color.green;
        //Debug.Log("Something hit me");
    } 
}
