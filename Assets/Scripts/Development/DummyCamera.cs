using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyCamera : MonoBehaviour
{
    [Tooltip("Camera speed is lower when the value goes down.")]
    public float speedLimiter = 5f;
    public float rotationSpeed = 1f;

    private float rotationSpeedMultiplier = 50;

    void Update()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * (speedLimiter / 100), 0, Input.GetAxis("Vertical") * (speedLimiter / 100)));

        Vector3 rotation = transform.eulerAngles;

        if (Input.GetKey(KeyCode.Q))
        {
            rotation.y -= rotationSpeed * rotationSpeedMultiplier * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rotation.y += rotationSpeed * rotationSpeedMultiplier * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.R))
        {
            rotation.x -= rotationSpeed * rotationSpeedMultiplier * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.F))
        {
            rotation.x += rotationSpeed * rotationSpeedMultiplier * Time.deltaTime;
        }
        transform.eulerAngles = rotation;

    }
}
