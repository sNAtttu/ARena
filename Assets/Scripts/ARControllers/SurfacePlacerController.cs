﻿

using System.Collections.Generic;
using GoogleARCore;
using UnityEngine;
using UnityEngine.Rendering;
using System.Linq;
using System;

public class SurfacePlacerController : MonoBehaviour
{
    public GameObject HeroPrefab;
    /// <summary>
    /// The first-person camera being used to render the passthrough camera image (i.e. AR background).
    /// </summary>
    public Camera FirstPersonCamera;

    /// <summary>
    /// A prefab for tracking and visualizing detected planes.
    /// </summary>
    public GameObject TrackedPlanePrefab;

    /// <summary>
    /// A list to hold new planes ARCore began tracking in the current frame. This object is used across
    /// the application to avoid per-frame allocations.
    /// </summary>
    private List<TrackedPlane> m_NewPlanes = new List<TrackedPlane>();

    /// <summary>
    /// A list to hold all planes ARCore is tracking in the current frame. This object is used across
    /// the application to avoid per-frame allocations.
    /// </summary>
    private List<TrackedPlane> m_AllPlanes = new List<TrackedPlane>();

    /// <summary>
    /// True if the app is in the process of quitting due to an ARCore connection error, otherwise false.
    /// </summary>
    private bool m_IsQuitting = false;

    private bool playerInitiated = false;

    private GameObject instantiatedObject;
    private DebugOverlay debugOverlay;
    private TouchHandler touchHandler;

    private void Awake()
    {
        touchHandler = GetComponent<TouchHandler>();
        if (touchHandler == null)
        {
            Debug.LogError("Touch handler not found from scene");
        }
    }

    private void Start()
    {
        debugOverlay = FindObjectOfType<DebugOverlay>();
    }

    public void Update()
    {

        // Check that motion tracking is tracking.
        if (Frame.TrackingState != TrackingState.Tracking)
        {
            const int lostTrackingSleepTimeout = 15;
            Screen.sleepTimeout = lostTrackingSleepTimeout;
            return;
        }

        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        // Iterate over planes found in this frame and instantiate corresponding GameObjects to visualize them.
        Frame.GetPlanes(m_NewPlanes, TrackableQueryFilter.New);
        for (int i = 0; i < m_NewPlanes.Count; i++)
        {
            // Instantiate a plane visualization prefab and set it to track the new plane. The transform is set to
            // the origin with an identity rotation since the mesh for our prefab is updated in Unity World
            // coordinates.
            GameObject planeObject = Instantiate(TrackedPlanePrefab, Vector3.zero, Quaternion.identity,
                transform);
            planeObject.GetComponent<SurfacePlaneVisualizer>().Initialize(m_NewPlanes[i]);
        }

        // Disable the snackbar UI when no planes are valid.
        Frame.GetPlanes(m_AllPlanes);

        debugOverlay.WritePlaneInformationToScreen(m_NewPlanes, m_AllPlanes);

        // If the player has not touched the screen, we are done with this update.
        Touch touch;
        if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }

        // Raycast against the location the player touched to search for planes.
        TrackableHit hit;
        TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinBounds | TrackableHitFlags.PlaneWithinPolygon;

        if (Session.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit))
        {
            if (playerInitiated)
            {
                touchHandler.HandlePlayerMovement(hit, instantiatedObject);
                return;
            }

            instantiatedObject = Instantiate(HeroPrefab, hit.Pose.position, hit.Pose.rotation);

            // Player should look at the camera but still be flush with the plane.
            instantiatedObject.transform.LookAt(FirstPersonCamera.transform);
            instantiatedObject.transform.rotation = Quaternion.Euler(0.0f,
                instantiatedObject.transform.rotation.eulerAngles.y, instantiatedObject.transform.rotation.z);

            playerInitiated = true;
        }
    }
}

