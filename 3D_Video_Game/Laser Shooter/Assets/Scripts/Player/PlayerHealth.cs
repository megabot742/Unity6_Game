using System;
using System.Linq;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Range(1, 9)]
    [SerializeField] int startingHealth = 6;
    [SerializeField] CinemachineVirtualCamera deathVirtualCamera;
    [SerializeField] Transform weaponCamera;
    [SerializeField] Image[] shieldBars;
    int currentHealth;
    int gameOverVirtualCameraPriortiy = 20;
    void Awake()
    {
        currentHealth = startingHealth;
        AdjustShieldUI();
    }
    public void TakeDamage(int hit)
    {
        currentHealth -= hit;
        //Debug.Log(hit + " Dmage");
        AdjustShieldUI();
        if(currentHealth <= 0)
        {
            weaponCamera.parent = null;
            deathVirtualCamera.Priority = gameOverVirtualCameraPriortiy;
            Destroy(this.gameObject);
        }
    }
    void AdjustShieldUI()
    {
        for(int i=0; i < shieldBars.Length; i++)
        {
            if(i < currentHealth)
            {
                shieldBars[i].gameObject.SetActive(true);
            }
            else
            {
                shieldBars[i].gameObject.SetActive(false);
            }
        }
        
    }
}
