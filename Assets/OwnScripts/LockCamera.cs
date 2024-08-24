using System.Collections;
using UnityEngine;

public class LockCamera : MonoBehaviour
{
    public Transform lockTarget; // el objetivo al que la cámara debe mirar durante el bloqueo
    public Transform unlockTarget; // el objetivo al que la cámara debe mirar al liberar
    public float transitionSpeed = 5f; // velocidad de transición hacia la posición bloqueada

    private Transform playerCamera;
    private bool isLocked = false;

    void Start()
    {
        playerCamera = Camera.main.transform;
    }

    public void CameraLock()
    {
        if (lockTarget != null)
        {
            isLocked = true;
            StartCoroutine(LockCameraToPosition());
        }
    }

    public void UnlockCamera()
    {
        isLocked = false;
        if (unlockTarget != null)
        {
            StartCoroutine(LookAtUnlockTarget());
        }
    }

    private IEnumerator LockCameraToPosition()
    {
        while (isLocked)
        {
            // lerp la rotación de la cámara hacia la posición bloqueada
            Quaternion targetRotation = Quaternion.LookRotation(lockTarget.position - playerCamera.position);
            playerCamera.rotation = Quaternion.Slerp(playerCamera.rotation, targetRotation, Time.deltaTime * transitionSpeed);

            // forzar la rotación de la cámara hacia la posición bloqueada
            playerCamera.rotation = targetRotation;

            yield return null;
        }
    }

    private IEnumerator LookAtUnlockTarget()
    {
        Quaternion targetRotation = Quaternion.LookRotation(unlockTarget.position - playerCamera.position);

        while (Quaternion.Angle(playerCamera.rotation, targetRotation) > 0.1f)
        {
            playerCamera.rotation = Quaternion.Slerp(playerCamera.rotation, targetRotation, Time.deltaTime * transitionSpeed);
            yield return null;
        }

        playerCamera.rotation = targetRotation;
    }
}
