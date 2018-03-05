using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{

    public bool touchHitPlayer = false;

    private PlayerUtilities playerUtilities;

    private void Start()
    {
        playerUtilities = GetComponent<PlayerUtilities>();
    }

    public void HandleCollisionEvent(string collidedBodyPartTag)
    {
        touchHitPlayer = true;
        if (collidedBodyPartTag == Utilities.PlayerConstants.TagPlayerBody)
        {
            playerUtilities.SendInputFsmEvent(Utilities.PlayerConstants.EventTouchBody);
        }
        else if (collidedBodyPartTag == Utilities.PlayerConstants.TagPlayerHead)
        {
            playerUtilities.SendInputFsmEvent(Utilities.PlayerConstants.EventTouchHead);
        }
        else if (collidedBodyPartTag == Utilities.PlayerConstants.TagPlayerLeftArm)
        {
            playerUtilities.SendInputFsmEvent(Utilities.PlayerConstants.EventTouchLeftArm);
        }
        else if (collidedBodyPartTag == Utilities.PlayerConstants.TagPlayerRightArm)
        {
            playerUtilities.SendInputFsmEvent(Utilities.PlayerConstants.EventTouchRightArm);
        }
        else
        {
            Debug.LogWarning("Unknown object");
        }
    }
    
}
