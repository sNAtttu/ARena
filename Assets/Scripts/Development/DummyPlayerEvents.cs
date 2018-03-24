using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPlayerEvents : MonoBehaviour
{
    [Tooltip("By pressing P player takes this much damage")]
    public float damageAmount = 50;

    [Tooltip("By pressing O player heals this much health")]
    public float healAmount = 20;

    private PlayerStats playerStats;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            DoDamage();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Heal();
        }
    }

    private void DoDamage()
    {
        InitPlayerStats();
        playerStats.TakeDamage(damageAmount);
    }
    
    private void Heal()
    {
        InitPlayerStats();
        playerStats.Heal(healAmount);
    }

    private void InitPlayerStats()
    {
        if (playerStats == null)
        {
            playerStats = FindObjectOfType<PlayerStats>();
        }
    }

}
