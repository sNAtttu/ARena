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
    private PlayerUtilities playerUtilities;

    private void Start()
    {
        playerUtilities = GetComponent<PlayerUtilities>();
    }

    private void Update()
    {
        if (playerUtilities.GetInputFsmActiveState() == Utilities.PlayerConstants.StateWalking)
        {
            MoveAndRotatePlayerTransform(PlayerWalkingSpeed);
        }
        else if (playerUtilities.GetInputFsmActiveState() == Utilities.PlayerConstants.StateRunning)
        {
            MoveAndRotatePlayerTransform(PlayerRunningSpeed);
        }
        if (transform.position == endPoint)
        {
            playerUtilities.SendInputFsmEvent(Utilities.PlayerConstants.EventStop);
        }
    }

    private void MoveAndRotatePlayerTransform(float speed)
    {
        // Move player
        Vector3 targetDir = endPoint - transform.position;
        float movementStep = (speed * 0.1f) * Time.deltaTime;   
        transform.position = Vector3.MoveTowards(transform.position, endPoint, movementStep);

        // Rotate player
        float rotationStep = playerUtilities.IsPlayerWalking() ? PlayerRotationSpeed : PlayerRunningRotationSpeed;
        rotationStep = rotationStep * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, rotationStep, 0.0F);
        transform.rotation = Quaternion.LookRotation(newDir);

    }

    public void MovePlayer(Vector3 nextPosition)
    {
        if(playerUtilities.GetInputFsmActiveState() == Utilities.PlayerConstants.StateWalking)
        {
            playerUtilities.SendInputFsmEvent(Utilities.PlayerConstants.EventRun);
        }
        else
        {
            playerUtilities.SendInputFsmEvent(Utilities.PlayerConstants.EventWalk);
        }        
        endPoint = nextPosition;
    }
}
