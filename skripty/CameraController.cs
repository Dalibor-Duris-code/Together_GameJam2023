using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{ 
    public Transform player1;
    public Transform player2;
    public float dampTime = 0.4f;
    public float minDistance = 10;
    private Vector3 cameraPos;
    private Vector3 velocity = Vector3.zero;

    public float minX = 0f;
    public float maxX = 25.55f;
    public float minY = -0.3f;
    public float maxY = 0.3f;


    private void Update()
    {
        float distance = Vector2.Distance(player1.position, player2.position);
        if (distance < minDistance)
        {
            Vector3 center = (player1.position + player2.position) / 2f;
            cameraPos = new Vector3(center.x, center.y, -10f);
        }
        else
        {
            Vector3 cameraPos1 = new Vector3(player1.position.x, player1.position.y, -10f);
            Vector3 cameraPos2 = new Vector3(player2.position.x, player2.position.y, -10f);
            cameraPos = (cameraPos1 + cameraPos2) / 2f;
        }

        // Get the camera's viewport dimensions
        float camHeight = Camera.main.orthographicSize;
        float camWidth = camHeight * Camera.main.aspect;

        // Clamp the camera position within the game bounds
        float clampedX = Mathf.Clamp(cameraPos.x, minX, maxX);
        float clampedY = Mathf.Clamp(cameraPos.y, minY, maxY);
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(clampedX, clampedY, cameraPos.z), ref velocity, dampTime);
    }

}