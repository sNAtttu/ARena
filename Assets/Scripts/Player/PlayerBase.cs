using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerBase
{
    public float MaxHp;
    public float MaxStamina;

    private float healthPoints;
    private float stamina;
    private float attackPower;

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

    public float Stamina
    {
        get
        {
            return stamina;
        }

        set
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value >= MaxStamina)
            {
                value = MaxStamina;
            }
            stamina = value;
        }
    }

    public float AttackPower
    {
        get
        {
            return attackPower;
        }

        set
        {
            attackPower = value;
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

    public float Heal(float healthAmount)
    {
        HealthPoints += healthAmount;
        return HealthPoints;
    }

    public float TakeDamage(float damage)
    {
        if (HealthPoints <= 0)
        {
            return 0f;
        }
        HealthPoints -= damage;
        return HealthPoints;
    }

    public float RecoverStamina(float stamina)
    {
        Stamina += stamina;
        return Stamina;
    }

    public float DrainStamina(float stamina)
    {
        if (Stamina <= 0)
        {
            return 0f;
        }
        Stamina -= stamina;
        return Stamina;
    }

    public float GetPlayerHpPercent()
    {
        return HealthPoints / MaxHp;
    }

    public float GetPlayerStaminaPercent()
    {
        return Stamina / MaxStamina;
    }

}
