using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class RotateCam : MonoBehaviour
{
    public BoxCollider Box; 
    public float rotationSpeed = 10f;
    private float targetRotation = -35f;
    private float initialRotationY;
    private bool isRotating = false;

    public void Start()
    {
        initialRotationY = transform.rotation.eulerAngles.y; 
    }

    public void Update()
    {
        if (isRotating)
        {
            Rotate();
        }
    }

    public void OnPointerClickXR()
    {
        StartInteraction();
    }

    private void StartInteraction()
    {
        Box.enabled = false;
        isRotating = true;
    }

    private void Rotate()
    {
        if (transform.rotation.eulerAngles.y > targetRotation)
            {
                float rotationStep = rotationSpeed * Time.deltaTime;
                float currentRotationY = Mathf.MoveTowards(transform.rotation.eulerAngles.y, targetRotation, rotationStep);

                transform.rotation = Quaternion.Euler(0f, currentRotationY, 0);
            }
        
        else
            {
                isRotating = false;
            }
    }
}
    

