using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] float positiveMoveSpeed = 1f;
    LevellGenerator levellGenerator;
    void Start()
    {
        levellGenerator = FindFirstObjectByType<LevellGenerator>();
    }
    protected override void OnPickup()
    {
        levellGenerator.ChangeChunkMoveSpeed(positiveMoveSpeed);
        Debug.Log("More Speed");
    }
}
