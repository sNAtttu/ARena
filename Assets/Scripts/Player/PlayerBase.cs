using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerBase
{
    public float MaxHp;
    private float healthPoints;
    public int MaxStamina;
    public int Stamina;
    public int AttackPower;

    public float HealthPoints
    {
        get
        {
            return healthPoints;
        }

        set
        {
            if(value < 0)
            {
                value = 0;
            }
            else if(value >= MaxHp)
            {
                value = MaxHp;
            }
            healthPoints = value;
        }
    }

    public PlayerBase(float maxHp, float hp, int maxStamina, int stamina, int attackPower)
    {
        MaxHp = maxHp;
        HealthPoints = hp;
        MaxStamina = maxStamina;
        Stamina = stamina;
        AttackPower = attackPower;
    }

    public float TakeDamage(float damage)
    {
        if (HealthPoints == 0)
        {
            return 0f;
        }
        HealthPoints -= damage;
        return HealthPoints;
    }

    public float Heal(float healthAmount)
    {
        if(HealthPoints == 0)
        {
            return 0f;
        }
        HealthPoints += healthAmount;
        return HealthPoints;
    }

    public float GetPlayerHpPercent()
    {
        return HealthPoints / MaxHp;
    }

}
