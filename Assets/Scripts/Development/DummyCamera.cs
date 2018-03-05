using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyCamera : MonoBehaviour
{
    [Tooltip("Camera speed is lower when the value goes down.")]
    public float speedLimiter = 5f;
    void Update()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * (speedLimiter / 100), 0, Input.GetAxis("Vertical") * (speedLimiter / 100)));
    }
}
