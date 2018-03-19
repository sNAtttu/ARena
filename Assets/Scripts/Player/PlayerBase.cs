using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerBase
{
    public float MaxHp;
    public float HealthPoints;
    public int MaxStamina;
    public int Stamina;
    public int AttackPower;

    public bool IsDead;

    public PlayerBase(float maxHp, float hp, int maxStamina, int stamina, int attackPower)
    {
        MaxHp = maxHp;
        HealthPoints = hp;
        MaxStamina = maxStamina;
        Stamina = stamina;
        AttackPower = attackPower;
    }

    public float TakeDamage(int damage)
    {
        HealthPoints -= damage;
        CheckIsDead();
        return HealthPoints;
    }

    public float Heal(int healthAmount)
    {
        HealthPoints += healthAmount;
        return HealthPoints;
    }

    public void CheckIsDead()
    {
        if(HealthPoints <= 0)
        {
            IsDead = true;
        }
    }

    public float GetPlayerHpPercent()
    {
        Debug.Log(HealthPoints / MaxHp);
        return HealthPoints / MaxHp;
    }

}
