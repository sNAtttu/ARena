using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacter : MonoBehaviour
{
    public GameObject SpawnablePrefab;
    public Vector3 SpawnPosition;

    private GameObject SpawnedObject;

    // Use this for initialization
    void Start()
    {
        SpawnedObject = Instantiate(SpawnablePrefab, SpawnPosition, SpawnablePrefab.transform.rotation);
    }
}
