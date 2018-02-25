using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetection : MonoBehaviour
{
    private PlayerInputManager inputManager;
    // FOR DEBUGGING
    private void OnMouseDown()
    {
        HandleInputEvent(Input.mousePosition);
    }
    // Use this for initialization
    void Start()
    {
        inputManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInputManager>();
    }

    private void Update()
    {
        HandleTouchEvent();
    }

    private void HandleTouchEvent()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            HandleInputEvent(Input.GetTouch(0).position);
        }
    }

    private void HandleInputEvent(Vector3 inputPosition)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(inputPosition);
        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            inputManager.HandleCollisionEvent(objectHit.tag);
        }
    }

}
