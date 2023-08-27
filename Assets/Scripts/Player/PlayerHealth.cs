using UnityEngine;
using System;


public class PlayerHealth : MonoBehaviour
{
    internal PlayerManager playerManager;
    internal HealthSystem healthSystem;
    int initialHealth = 100;


    public void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
        healthSystem = new HealthSystem(initialHealth);
        playerManager.UpdateHealthUI(initialHealth);
    }

    public void TakeDamage(int amount)
    {
        healthSystem.TakeDamage(amount);
        Debug.Log("Attacked " + amount);
    }
}
