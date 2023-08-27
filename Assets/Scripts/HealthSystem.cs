using UnityEngine;
using System;

public class HealthSystem
{
    private int health;
    internal Action<int> healthChangedCallback;
    internal Action deathCallback;

    public HealthSystem(int initialHealth)
    {
        health = initialHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        healthChangedCallback?.Invoke(health);

        if (health <= 0)
        {
            deathCallback();
            // Player is dead
        }
    }
}
