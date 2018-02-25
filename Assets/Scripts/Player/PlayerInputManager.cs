using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    [Tooltip("These objects will be attached with collider script. Supports head, body and arms")]
    public List<GameObject> ColliderObjects;

    public bool touchHitPlayer = false;

    private PlayMakerFSM inputFSM;
    private Animator playerCharacterAnimator;
    private void Start()
    {
        inputFSM = GetComponent<PlayMakerFSM>();
        playerCharacterAnimator = transform.GetChild(0).GetComponent<Animator>();
        InitializeColliderObjects();
    }

    private void InitializeColliderObjects()
    {
        foreach (var colliderObject in ColliderObjects)
        {
            colliderObject.AddComponent<PlayerCollisionDetection>();
            Rigidbody attachedRigidbody = colliderObject.AddComponent<Rigidbody>();
            attachedRigidbody.useGravity = false;
            attachedRigidbody.isKinematic = true;
            if(colliderObject.tag == Utilities.PlayerConstants.TagPlayerBody)
            {
                BoxCollider collider = colliderObject.AddComponent<BoxCollider>();
                collider.center = new Vector3(0.15f, 0, 0);
                collider.size = new Vector3(0.5f, 0.5f, 0.5f);
            }
            else if(colliderObject.tag == Utilities.PlayerConstants.TagPlayerHead)
            {
                BoxCollider collider = colliderObject.AddComponent<BoxCollider>();
                collider.center = new Vector3(-0.07f, 0, 0);
                collider.size = new Vector3(0.5f, 1f, 0.5f);
            }
            else if (colliderObject.tag == Utilities.PlayerConstants.TagPlayerLeftArm ||
                colliderObject.tag == Utilities.PlayerConstants.TagPlayerRightArm )
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

    public void HandleCollisionEvent(string collidedBodyPartTag)
    {
        touchHitPlayer = true;
        if (collidedBodyPartTag == Utilities.PlayerConstants.TagPlayerBody)
        {
            inputFSM.SendEvent(Utilities.PlayerConstants.EventTouchBody);
        }
        else if (collidedBodyPartTag == Utilities.PlayerConstants.TagPlayerHead)
        {
            inputFSM.SendEvent(Utilities.PlayerConstants.EventTouchHead);
        }
        else if (collidedBodyPartTag == Utilities.PlayerConstants.TagPlayerLeftArm)
        {
            inputFSM.SendEvent(Utilities.PlayerConstants.EventTouchLeftArm);
        }
        else if (collidedBodyPartTag == Utilities.PlayerConstants.TagPlayerRightArm)
        {
            inputFSM.SendEvent(Utilities.PlayerConstants.EventTouchRightArm);
        }
        else
        {
            Debug.LogWarning("Unknown object");
        }
    }

}
