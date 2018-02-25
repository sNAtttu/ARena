using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyCamera : MonoBehaviour
{
    // Update is called once per frame
    public float speedLimiter = 0.05f;
    void Update()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * speedLimiter, 0, Input.GetAxis("Vertical") * speedLimiter));
    }
}
