using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils.Delegates;

public class Health : MonoBehaviour
{
    [Header("Atributes")]
    [SerializeField] int MaxHealth;
    int health;

    [Header("Reference")]
    [SerializeField] Slider healthBar;

    public voidDelegateNoArgs OnDeath;
    public voidDelegateNoArgs OnGetHit;

    public bool isAlive;
    
    private void OnEnable()
    {
        Restart();
    }

    private void OnDisable()
    {
        OnDeath = null;
        OnGetHit = null;
    }

    void Restart()
    {
        isAlive = true;
        health = MaxHealth;
        if (healthBar != null)
        {
            healthBar.maxValue = MaxHealth;
            healthBar.value = MaxHealth;
        }
    }

    public void Damage(int amount)
    {
        if (!isAlive) return;

        health -= amount;

        if(health <= 0)
        {
            health = 0;
            isAlive = false;
            Debug.Log(gameObject.name + " <color=grey>is dead</color>");
            OnDeath?.Invoke();
        }
        else
        {
            OnGetHit?.Invoke();
        }

        //TODO: Hide healthbar when full
        if (healthBar != null)
        {
            healthBar.maxValue = MaxHealth;
            healthBar.value = health;
        }
    }
}
