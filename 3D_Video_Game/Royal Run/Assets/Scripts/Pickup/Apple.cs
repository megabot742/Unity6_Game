using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] float positiveMoveSpeed = 1f;
    [SerializeField] AudioClip appleAudio;
    [SerializeField, Range(0,1)] float audioVolume;
    LevellGenerator levellGenerator;
    public void Init(LevellGenerator levellGenerator)
    {
        this.levellGenerator = levellGenerator;
    }
    protected override void OnPickup()
    {
        levellGenerator.ChangeChunkMoveSpeed(positiveMoveSpeed);
        AudioSource.PlayClipAtPoint(appleAudio,transform.position, audioVolume);
    }
}
