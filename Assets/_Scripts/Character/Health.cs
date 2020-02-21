using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("Atributes")]
    [SerializeField] int MaxHealth;
    int health;

    [Header("Reference")]
    [SerializeField] Slider healthBar;

    private void OnEnable()
    {
        health = MaxHealth;
        if (healthBar != null)
        {
            healthBar.maxValue = MaxHealth;
            healthBar.value = MaxHealth;
        }
    }

    public void Damage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            health = 0;
            Debug.Log(gameObject.name + " <color=grey>is dead</color>");
        }
        else
        {
            Debug.Log(gameObject.name + " received damage <color=green>(" + health + " / " + MaxHealth + ")</color>");
        }

        if (healthBar != null) healthBar.value = health;
    }
}
