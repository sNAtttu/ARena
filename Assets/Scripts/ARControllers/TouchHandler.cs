using GoogleARCore;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHandler : MonoBehaviour
{
    /// <summary>
    /// Sends information about clicked coordinates.
    /// Function checks if the clicked position is on the same platform or does player need
    /// to move up or down.
    /// </summary>
    /// <param name="hit"></param>
    public void HandlePlayerMovement(TrackableHit hit, GameObject playerGameObject)
    {
        var inputManager = playerGameObject.GetComponent<PlayerInputManager>();
        var movementManager = playerGameObject.GetComponent<PlayerMovementManager>();

        if (inputManager.touchHitPlayer)
        {
            inputManager.touchHitPlayer = false;
            return;
        }

        Vector3 worldHitPos = hit.Pose.position;
        Vector3 playerPos = playerGameObject.transform.position;

        float roundedClickedPosition = (float)Math.Round(worldHitPos.y, 2, MidpointRounding.ToEven);
        float roundedPlayerPosition = (float)Math.Round(playerPos.y, 2, MidpointRounding.ToEven);

        if (roundedPlayerPosition == roundedClickedPosition)
        {
            movementManager.MovePlayer(worldHitPos);
        }
        else if (roundedClickedPosition < roundedPlayerPosition)
        {
            movementManager.MovePlayerToLowerPlatform(worldHitPos);
        }
        else if (roundedClickedPosition > roundedPlayerPosition)
        {
            movementManager.MovePlayerToHigherPlatform(worldHitPos);
        }

        return;
    }
}
