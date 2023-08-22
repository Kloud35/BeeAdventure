using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public static EnemyHealthManager instance;
    public int maxHealth = 3;
    public int currentHealth;

    public HealthBar healthBar;

    private void Awake()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        MakeSingleTon();
    }
    public void TakeDamage()
    {
        currentHealth--;
        healthBar.SetHealth(currentHealth);
    }
    public void MakeSingleTon()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
