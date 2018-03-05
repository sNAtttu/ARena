using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionDetection : MonoBehaviour
{

    private EnemyTouchHandler touchHandler;

    public void SetTouchHandler(EnemyTouchHandler handler)
    {
        touchHandler = handler;
    }

    // FOR DEBUGGING
    private void OnMouseDown()
    {
        HandleInputEvent(Input.mousePosition);
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
            touchHandler.HandleCollisionEvent(objectHit.tag);
        }
    }
}
