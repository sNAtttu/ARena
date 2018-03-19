using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Image playerHealthBar;

    private PlayerBase playerStats;
    // Use this for initialization
    void Start()
    {
        if(playerHealthBar == null)
        {
            Debug.LogError("Healthbar image missing");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetPlayer(PlayerBase player)
    {
        playerStats = player;
        playerHealthBar.fillAmount = GetPlayerHealthPercent();
    }

    public PlayerBase GetPlayerStats()
    {
        return playerStats;
    }

    public float GetPlayerHealthPercent()
    {
        return playerStats.GetPlayerHpPercent();
    }

}
