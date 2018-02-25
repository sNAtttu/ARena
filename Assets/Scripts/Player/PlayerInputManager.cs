using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    [Tooltip("These objects will be attached with collider script. Supports head, body and arms")]
    public List<GameObject> ColliderObjects;

    public bool touchHitPlayer = false;

    private PlayerUtilities playerUtilities;

    private void Start()
    {
        playerUtilities = GetComponent<PlayerUtilities>();
        InitializeColliderObjects();
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
    private void InitializeColliderObjects()
    {
        foreach (var colliderObject in ColliderObjects)
        {
            colliderObject.AddComponent<PlayerCollisionDetection>();
            Rigidbody attachedRigidbody = colliderObject.AddComponent<Rigidbody>();
            attachedRigidbody.useGravity = false;
            attachedRigidbody.isKinematic = true;
            if (colliderObject.tag == Utilities.PlayerConstants.TagPlayerBody)
            {
                BoxCollider collider = colliderObject.AddComponent<BoxCollider>();
                collider.center = new Vector3(0.15f, 0, 0);
                collider.size = new Vector3(0.5f, 0.5f, 0.5f);
            }
            else if (colliderObject.tag == Utilities.PlayerConstants.TagPlayerHead)
            {
                BoxCollider collider = colliderObject.AddComponent<BoxCollider>();
                collider.center = new Vector3(-0.07f, 0, 0);
                collider.size = new Vector3(0.5f, 1f, 0.5f);
            }
            else if (colliderObject.tag == Utilities.PlayerConstants.TagPlayerLeftArm ||
                colliderObject.tag == Utilities.PlayerConstants.TagPlayerRightArm)
            {
                BoxCollider collider = colliderObject.AddComponent<BoxCollider>();
                collider.center = new Vector3(0.06f, 0, 0);
                collider.size = new Vector3(0.4f, 0.1f, 0.1f);
            }
            else
            {
                Debug.LogWarning("Unknown object");
            }
        }
    }
}
