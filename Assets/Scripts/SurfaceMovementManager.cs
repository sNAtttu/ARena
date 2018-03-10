using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceMovementManager : MonoBehaviour
{
    private GameObject Player;
    private PlayerMovementManager playerMovementManager;
    private PlatformManager platformManager;
    public string platformId;


    private void Start()
    {
        platformManager = FindObjectOfType<PlatformManager>();
        platformId = Guid.NewGuid().ToString();
        platformManager.SetPlatformToFoundPlatforms(platformId, gameObject);
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // FOR DEBUGGING
    private void OnMouseDown()
    {
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }

        Vector3 worldPos = GetInputWorldPosition(Input.mousePosition);

        playerMovementManager.MovePlayer(worldPos, platformId);
        
    }

    private void Update()
    {
        HandleTouchEvent();
    }

    private void HandleTouchEvent()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector3 worldPos = GetInputWorldPosition(Input.GetTouch(0).position);
            playerMovementManager.MovePlayer(worldPos, platformId);
        }
    }

    private Vector3 GetInputWorldPosition(Vector3 inputPosition)
    {
        if (playerMovementManager == null)
        {
            playerMovementManager = FindObjectOfType<PlayerMovementManager>();
            if(playerMovementManager == null)
            {
                Debug.LogError("Can't find playermovementmanager");
            }
        }
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(inputPosition);
        if (Physics.Raycast(ray, out hit))
        { 
            return hit.point;
        }
        else
        {
            return Player.transform.position;
        }
    }

}
