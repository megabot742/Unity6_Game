using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]float xValue = 0;
    [SerializeField]float yValue = 0.01f;
    [SerializeField]float zValue = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(xValue, yValue, zValue);
    }
}
