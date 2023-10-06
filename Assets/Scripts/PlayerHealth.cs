using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDamaged;

    public int maxHealth = 3;
    public int currentHealth;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        OnPlayerDamaged?.Invoke();

        if(currentHealth <= 0)
        {
            // You Died
            anim.SetBool("IsDead", true);
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
