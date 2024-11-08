using UnityEngine;

public class FlyAtPlayer : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float moveSpeed = 0f;
    Vector3 playerPostion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerPostion = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPostion, Time.deltaTime*moveSpeed);
    }
}
