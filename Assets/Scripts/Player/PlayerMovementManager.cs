using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManager : MonoBehaviour
{
    public float PlayerWalkingSpeed = 5.0f;
    public float PlayerRunningSpeed = 5.0f;
    public float PlayerRotationSpeed = 5.0f;
    public float PlayerRunningRotationSpeed = 5.0f;
    public float PlayerJumpRotationSpeed = 5.0f;
    public float PlayerJumpUpPower = 1.0f;
    public float PlayerJumpDownPower = 0.5f;
    public float PlayerJumpDuration = 1.0f;

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
        else if (playerUtilities.IsPlayerJumping())
        {
            RotatePlayer(endPoint);
        }
        if (transform.position == endPoint)
        {
            playerUtilities.SendInputFsmEvent(Utilities.PlayerConstants.EventStop);
        }
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
    }

    private void MoveAndRotatePlayerTransform(float speed)
    {
        // Move player
        Vector3 targetDir = endPoint - transform.position;
        float movementStep = (speed * 0.1f) * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, endPoint, movementStep);

        RotatePlayer(targetDir);

    }

    private void RotatePlayer(Vector3 targetDirection)
    {
        // Rotate player
        float rotationStep = playerUtilities.IsPlayerWalking() ? PlayerRotationSpeed : PlayerRunningRotationSpeed;
        if (playerUtilities.IsPlayerJumping())
        {
            rotationStep = PlayerJumpRotationSpeed;
        }
        else
        {
            rotationStep = rotationStep * Time.deltaTime;
        }
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDirection, rotationStep, 0.0F);
        transform.rotation = Quaternion.LookRotation(newDir);
    }


    public void MovePlayer(Vector3 nextPosition)
    {
        if (playerUtilities.GetInputFsmActiveState() == Utilities.PlayerConstants.StateWalking)
        {
            playerUtilities.SendInputFsmEvent(Utilities.PlayerConstants.EventRun);
        }
        else
        {
            playerUtilities.SendInputFsmEvent(Utilities.PlayerConstants.EventWalk);
        }
        endPoint = nextPosition;
    }

    public void MovePlayerToHigherPlatform(Vector3 nextPosition)
    {
        if (playerUtilities.IsPlayerJumping() || playerUtilities.IsPlayerMoving())
        {
            return;
        }
        playerUtilities.SendInputFsmEvent(Utilities.PlayerConstants.EventJumpUp);
        PlayerJumpToPosition(nextPosition, PlayerJumpUpPower);
    }

    public void MovePlayerToLowerPlatform(Vector3 nextPosition)
    {
        if (playerUtilities.IsPlayerJumping() || playerUtilities.IsPlayerMoving())
        {
            return;
        }
        playerUtilities.SendInputFsmEvent(Utilities.PlayerConstants.EventJumpDown);
        PlayerJumpToPosition(nextPosition, PlayerJumpDownPower);
    }

    public void PlayerJumpToPosition(Vector3 nextPosition, float jumpPower)
    {
        endPoint = nextPosition;
        GetComponent<Transform>().DOJump(nextPosition, jumpPower, 1, PlayerJumpDuration)
            .AppendCallback(PlayerJumpFinishedCallback);
    }

    private void PlayerJumpFinishedCallback()
    {
        playerUtilities.SendInputFsmEvent(Utilities.PlayerConstants.EventLand);
    }

}
