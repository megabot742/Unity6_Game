using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] float timeToWait = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timeToWait)
        {
            Debug.Log("Look out Below");
        }
        //Debug.Log("Time every second: " + Time.time);
    }
}
