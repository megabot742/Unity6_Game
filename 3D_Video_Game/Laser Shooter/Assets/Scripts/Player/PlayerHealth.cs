using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int startingHealth = 6;
    int currentHealth;
    void Awake()
    {
        currentHealth = startingHealth;
    }
    public void TakeDamage(int hit)
    {
        currentHealth -= hit;
        Debug.Log(hit + " Dmage");
        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
