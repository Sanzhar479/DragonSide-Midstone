using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private UnityEvent onDamage;
    [SerializeField] private UnityEvent onHeal;
    [SerializeField] public UnityEvent onDie;
    //[SerializeField] public HealthChangeEvent onChange;

    public int Health => health;

    public void ModifyHealth(int healthDelta)
    {
        if (health <= 0) return;

        health += healthDelta;
        //onChange?.Invoke(health);

        if (healthDelta < 0)
        {
            onDamage?.Invoke();
        }

        if (healthDelta > 0)
        {
            onHeal?.Invoke();
        }

        if (health <= 0)
        {
            onDie?.Invoke();
        }
    }

    [Serializable]
    public class HealthChangeEvent : UnityEvent<int>
    {
    }
}
