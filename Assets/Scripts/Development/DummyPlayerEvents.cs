using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPlayerEvents : MonoBehaviour
{
    [Tooltip("By pressing P player takes this much damage")]
    public float damageAmount = 50;

    [Tooltip("By pressing O player heals this much health")]
    public float healAmount = 20;

    [Tooltip("By pressing K player uses this much stamina")]
    public float jumpStaminaDrainAmount = 20;

    [Tooltip("Pressing continuously L down simulates running. Stamina bar should go gradually down this amount on every update.")]
    public float runningStaminaAmount = 0.5f;

    public float staminaRegenerationAmount = 0.5f;

    private PlayerStatsActions playerStatsActions;

    private void Start()
    {
        InitPlayerStats();
    }

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
        if (Input.GetKeyDown(KeyCode.K))
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.L))
        {
            Run();
        }
        else
        {
            Recover();
        }
    }

    private void DoDamage()
    {
        playerStatsActions.TakeDamage(damageAmount);
    }
    
    private void Heal()
    {
        playerStatsActions.Heal(healAmount);
    }

    private void Jump()
    {
        playerStatsActions.DrainStamina(jumpStaminaDrainAmount);
    }

    private void Run()
    {
        playerStatsActions.DrainStamina(runningStaminaAmount);
    }

    private void Recover()
    {
        playerStatsActions.RecoverStamina(staminaRegenerationAmount);
    }

    private void InitPlayerStats()
    {
        if (playerStatsActions == null)
        {
            playerStatsActions = FindObjectOfType<PlayerStatsActions>();
        }
    }

}
