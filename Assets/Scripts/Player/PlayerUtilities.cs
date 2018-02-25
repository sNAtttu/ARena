using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUtilities : MonoBehaviour
{

    private PlayMakerFSM inputFSM;

    private void Start()
    {
        inputFSM = GetComponent<PlayMakerFSM>();
        
    }

    public bool IsPlayerRunning()
    {
        return inputFSM.ActiveStateName == Utilities.PlayerConstants.StateRunning;
    }

    public bool IsPlayerWalking()
    {
        return inputFSM.ActiveStateName == Utilities.PlayerConstants.StateWalking;
    }

    public bool IsPlayerMoving()
    {
        return inputFSM.ActiveStateName == Utilities.PlayerConstants.StateWalking || inputFSM.ActiveStateName == Utilities.PlayerConstants.StateRunning;
    }

    public void SendInputFsmEvent(string fsmEvent)
    {
        inputFSM.SendEvent(fsmEvent);
    }

    public string GetInputFsmActiveState()
    {
        return inputFSM.ActiveStateName;
    }



}
