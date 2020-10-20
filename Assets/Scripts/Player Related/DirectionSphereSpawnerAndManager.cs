﻿using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// This is to be attached to the player prefab
/// </summary>
public class DirectionSphereSpawnerAndManager : MonoBehaviour
{
    [SerializeField]
    private GameObject directionSpherePrefab;
    private GameObject dirSphereObject;
    private DirectionSphere directionSphere;
    private bool directionSphereIsSet = false;

    private Vector2 lookInput;

    //void Awake()
    //{
    //    SpawnCharacterVisualsPrefab.OnVisualsSpawnedEvent += SpawnDirSphere;
    //}

    public void SpawnDirSphere(GameObject characterVisualsInstance)
    {
        dirSphereObject = Instantiate(directionSpherePrefab, this.transform.position, Quaternion.identity);
        directionSphere = dirSphereObject.GetComponent<DirectionSphere>();
        directionSphere.playerToFollow = characterVisualsInstance;
        directionSphereIsSet = true;
    }

    public GameObject GetPrefab()
    {
        //if (directionSphereIsSet) return dirSphereObject;
        //else
        //{
        //    Debug.LogError("DirSphere not ready");
        //    return null;
        //}
        return dirSphereObject;
    }

    public void OnLook(InputValue value)
    {
        if (directionSphereIsSet)
        {
            lookInput = value.Get<Vector2>().normalized;
            directionSphere.directionVector = lookInput;
        }
    }
}
