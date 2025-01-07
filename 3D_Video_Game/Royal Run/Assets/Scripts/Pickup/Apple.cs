using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] float positiveMoveSpeed = 1f;
    LevellGenerator levellGenerator;
    public void Init(LevellGenerator levellGenerator)
    {
        this.levellGenerator = levellGenerator;
    }
    protected override void OnPickup()
    {
        levellGenerator.ChangeChunkMoveSpeed(positiveMoveSpeed);
        //Debug.Log("More Speed");
    }
}
