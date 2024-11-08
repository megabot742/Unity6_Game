using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] float timeToWait = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    MeshRenderer myMeshRenderer;
    Rigidbody myRigibody;
    void Start()
    {
        myMeshRenderer = GetComponent<MeshRenderer>();
        myMeshRenderer.enabled = false;
        myRigibody = GetComponent<Rigidbody>();
        myRigibody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timeToWait)
        {
            //Debug.Log("Look out Below");
            myMeshRenderer.enabled = true;
            myRigibody.useGravity = true;
        }
        //Debug.Log("Time every second: " + Time.time);
    }
}
