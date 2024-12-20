using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem destroyVFX;
    [SerializeField] int hitPoints = 4;
    [SerializeField] int scoreValue = 10;
    Scoreboard scoreboard;
    private void Start() {
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }
    private void OnParticleCollision(GameObject other) 
    {
        ProcessHit();
    }
    void ProcessHit()
    {
        hitPoints--;
        if(hitPoints <=  0)
        {
            scoreboard.IncreaseScore(scoreValue);
            Instantiate(destroyVFX,transform.position, Quaternion.identity); // Quaternion.identity = default rotations
            Destroy(gameObject);
        }
    }
}
