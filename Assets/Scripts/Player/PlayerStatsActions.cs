using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsActions : MonoBehaviour
{

    private GameObject playerHealthbar;
    private GameObject playerStaminabar;

    private PlayerBase playerStats;
    // Use this for initialization
    void Start()
    {

        playerHealthbar = GameObject.FindGameObjectWithTag(Utilities.PlayerConstants.TagPlayerHealthBar);
        playerStaminabar = GameObject.FindGameObjectWithTag(Utilities.PlayerConstants.TagPlayerStaminaBar);
        if(playerStaminabar == null || playerHealthbar == null)
        {
            Debug.LogError("Staminabar or healthbar missing");
        }

    }

    public float TakeDamage(float damage)
    {
        float healthLeft = playerStats.TakeDamage(damage);
        UpdatePlayerStatusBar(playerHealthbar, Utilities.PlayerConstants.PlayerStatusBar.Health);
        return healthLeft;
    }

    public void Heal(float healAmount)
    {
        playerStats.Heal(healAmount);
        UpdatePlayerStatusBar(playerHealthbar, Utilities.PlayerConstants.PlayerStatusBar.Health);
    }

    public void RecoverStamina(float staminaAmount)
    {
        playerStats.RecoverStamina(staminaAmount);
        UpdatePlayerStatusBar(playerStaminabar, Utilities.PlayerConstants.PlayerStatusBar.Stamina);
    }

    public float DrainStamina(float staminaAmount)
    {
        float staminaLeft = playerStats.DrainStamina(staminaAmount);
        UpdatePlayerStatusBar(playerStaminabar, Utilities.PlayerConstants.PlayerStatusBar.Stamina);
        return staminaLeft;
    }

    public void SetPlayer(PlayerBase player)
    {
        playerStats = player;
    }

    public PlayerBase GetPlayerStats()
    {
        return playerStats;
    }

    public float GetPlayerHealthPercent()
    {
        return playerStats.GetPlayerHpPercent();
    }

    public float GetPlayerStaminaPercent()
    {
        return playerStats.GetPlayerStaminaPercent();
    }

    private void UpdatePlayerStatusBar(GameObject statusBar,
        Utilities.PlayerConstants.PlayerStatusBar barType)
    {
        Vector3 barLocalScale = statusBar.transform.localScale;
        if(barType == Utilities.PlayerConstants.PlayerStatusBar.Health)
        {
            barLocalScale.x = GetPlayerHealthPercent();
            playerHealthbar.transform.localScale = barLocalScale;
        }
        else if(barType == Utilities.PlayerConstants.PlayerStatusBar.Stamina)
        {
            barLocalScale.x = GetPlayerStaminaPercent();
            playerStaminabar.transform.localScale = barLocalScale;
        }
        
    }
}
