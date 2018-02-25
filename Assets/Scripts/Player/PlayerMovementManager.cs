using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManager : MonoBehaviour
{
    public float PlayerWalkingSpeed = 5.0f;
    public float PlayerRunningSpeed = 5.0f;
    public float PlayerRotationSpeed = 5.0f;
    public float PlayerRunningRotationSpeed = 5.0f;

    private Vector3 endPoint;
    private PlayMakerFSM inputFSM;

    private void Start()
    {
        inputFSM = GetComponent<PlayMakerFSM>();
    }

    private void Update()
    {
        if (inputFSM.ActiveStateName == Utilities.PlayerConstants.StateWalking)
        {
            MoveAndRotatePlayerTransform(PlayerWalkingSpeed);
        }
        else if (inputFSM.ActiveStateName == Utilities.PlayerConstants.StateRunning)
        {
            MoveAndRotatePlayerTransform(PlayerRunningSpeed);
        }
        if (transform.position == endPoint)
        {
            inputFSM.SendEvent(Utilities.PlayerConstants.EventStop);
        }
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

    private void MoveAndRotatePlayerTransform(float speed)
    {
        // Move player
        Vector3 targetDir = endPoint - transform.position;
        float movementStep = (speed * 0.1f) * Time.deltaTime;   
        transform.position = Vector3.MoveTowards(transform.position, endPoint, movementStep);

        // Rotate player
        float rotationStep = IsPlayerWalking() ? PlayerRotationSpeed : PlayerRunningRotationSpeed;
        rotationStep = rotationStep * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, rotationStep, 0.0F);
        transform.rotation = Quaternion.LookRotation(newDir);

    }

    public void MovePlayer(Vector3 nextPosition)
    {
        if(inputFSM.ActiveStateName == Utilities.PlayerConstants.StateWalking)
        {
            inputFSM.SendEvent(Utilities.PlayerConstants.EventRun);
        }
        else
        {
            inputFSM.SendEvent(Utilities.PlayerConstants.EventWalk);
        }        
        endPoint = nextPosition;
    }
}
