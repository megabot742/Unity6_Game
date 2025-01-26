using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] int startingHealth = 3;
    int currentHealth;
    void Awake()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int hit)
    {
        currentHealth -= hit;
        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
