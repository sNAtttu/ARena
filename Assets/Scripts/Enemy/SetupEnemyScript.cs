using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupEnemyScript : MonoBehaviour
{
    [Tooltip("These objects will be attached with collider script. Supports head, body and arms")]
    public List<GameObject> ColliderObjects;

    private EnemyTouchHandler touchHandler;
    // Use this for initialization
    void Awake()
    {
        touchHandler = GetComponent<EnemyTouchHandler>();
    }
    private void Start()
    {
        InitializeColliderObjects();
    }
    private void InitializeColliderObjects()
    {
        foreach (var colliderObject in ColliderObjects)
        {
            var colliderComponent = colliderObject.AddComponent<EnemyCollisionDetection>();
            colliderComponent.SetTouchHandler(touchHandler);
            Rigidbody attachedRigidbody = colliderObject.AddComponent<Rigidbody>();
            attachedRigidbody.useGravity = false;
            attachedRigidbody.isKinematic = true;
            if (colliderObject.tag == Utilities.EnemyConstants.TagEnemyBody)
            {
                BoxCollider collider = colliderObject.AddComponent<BoxCollider>();
                collider.center = new Vector3(0.15f, 0, 0);
                collider.size = new Vector3(0.5f, 0.5f, 0.5f);
            }
            else if (colliderObject.tag == Utilities.EnemyConstants.TagEnemyHead)
            {
                BoxCollider collider = colliderObject.AddComponent<BoxCollider>();
                collider.center = new Vector3(-0.07f, 0, 0);
                collider.size = new Vector3(0.5f, 1f, 0.5f);
            }
            else if (colliderObject.tag == Utilities.EnemyConstants.TagEnemyLeftArm ||
                colliderObject.tag == Utilities.EnemyConstants.TagEnemyRightArm)
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
