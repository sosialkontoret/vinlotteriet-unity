using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    private Transform transformToTeleport;
    private Vector3 originalPoint;

    // Start is called before the first frame update
    void Start()
    {
        originalPoint = transformToTeleport.position;
    }

    public void TeleportTransform()
    {
        transformToTeleport.position = originalPoint;
    }

}
