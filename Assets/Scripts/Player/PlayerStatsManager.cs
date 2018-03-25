using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    public float RunningStaminaDrain = 1f;
    public float RecoverStaminaAmount = 0.5f;

    private PlayMakerFSM playerFSM;
    private PlayerStatsActions actions;
    private PlayerUtilities playerUtilities;
    // Use this for initialization
    void Start()
    {
        playerUtilities = GetComponent<PlayerUtilities>();
        actions = GetComponent<PlayerStatsActions>();
        playerFSM = GetComponent<PlayMakerFSM>();
    }

    // Update is called once per frame
    void Update()
    {
        HandlePlayerStamina(playerFSM.ActiveStateName == Utilities.PlayerConstants.StateRunning);
    }

    private void HandlePlayerStamina(bool isRunning)
    {
        if (isRunning)
        {
            float staminaLeft = actions.DrainStamina(RunningStaminaDrain);
            if(staminaLeft <= 0)
            {
                playerUtilities.SendInputFsmEvent(Utilities.PlayerConstants.EventOutOfBreath);
            }
        }
        else
        {
            actions.RecoverStamina(RecoverStaminaAmount);
        }
        
    }

}
