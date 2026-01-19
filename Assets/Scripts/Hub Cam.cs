using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubCam : MonoBehaviour
{
    public Transform centerObject; // Assign your player or a fixed object here
    public float offsetStrength = 0.5f; // Controls how much the camera moves

    void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = -10;

        Vector3 centerPoint = centerObject != null ? centerObject.position : Vector3.zero;
        Vector3 rawOffset = mouseWorldPos - centerPoint;
        Vector3 scaledOffset = rawOffset * offsetStrength;

        transform.position = centerPoint + scaledOffset / 2;
    }
}
