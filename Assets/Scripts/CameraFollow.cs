using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpped = 2f;
    public Transform target;
    public float y;

    // Update is called once per frame
    void Update()
    {
        float targetX = target.position.x;
        float currentY = y; // Keep the current Y position of the camera
        float currentZ = transform.position.z;
        Vector3 newPos = new Vector3(targetX,currentY,currentZ);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpped * Time.deltaTime);
        // Debug.Log("Camera Position: " + transform.position);
        // Debug.Log("Target Position: " + target.position);
    }
}
