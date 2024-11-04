using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]float moveSpeed = 10f;   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PrintInstructuon();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    void PrintInstructuon()
    {
        Debug.Log("Welcome to the game!");
        Debug.Log("Move using arrow keys or WASD");
        Debug.Log("Try to avoid the obstacles");
    }
    void MovePlayer()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float yValue = 0f;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(xValue, yValue, zValue);
    }
}
