using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceMovementManager : MonoBehaviour
{
    private GameObject Player;
    private PlayerMovementManager playerMovementManager;


    private void Start()
    {
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
        float roundedClickedPosition = (float)Math.Round(worldPos.y, 2, MidpointRounding.ToEven);
        float roundedPlayerPosition = (float)Math.Round(Player.transform.position.y, 2, MidpointRounding.ToEven);
        if(roundedPlayerPosition == roundedClickedPosition)
        {
            playerMovementManager.MovePlayer(worldPos);
        }
        else if(roundedClickedPosition < roundedPlayerPosition)
        {
            playerMovementManager.MovePlayerToLowerPlatform(worldPos);
        }
        else if (roundedClickedPosition > roundedPlayerPosition)
        {
            playerMovementManager.MovePlayerToHigherPlatform(worldPos);
        }
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
            playerMovementManager.MovePlayer(worldPos);
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
