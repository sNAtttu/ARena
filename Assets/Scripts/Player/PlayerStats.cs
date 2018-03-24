using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        float remainingPoints = playerStats.TakeDamage(damage);
        if (remainingPoints <= 0)
        {
            SetHealthbarToZero();
            return;
        }
        UpdatePlayerHealthBar();
    }

    public void Heal(float healAmount)
    {
        float remainingPoints = playerStats.Heal(healAmount);
        if (remainingPoints <= 0)
        {
            SetHealthbarToZero();
            return;
        }     
        UpdatePlayerHealthBar();
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

    private void SetHealthbarToZero()
    {
        Vector3 healthbarLocalScale = playerHealthbar.transform.localScale;
        healthbarLocalScale.x = 0;
        playerHealthbar.transform.localScale = healthbarLocalScale;
    }

    private void UpdatePlayerHealthBar()
    {
        Vector3 healthbarLocalScale = playerHealthbar.transform.localScale;
        healthbarLocalScale.x = GetPlayerHealthPercent();
        playerHealthbar.transform.localScale = healthbarLocalScale;
    }

}
