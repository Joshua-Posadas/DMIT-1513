using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public InputAction swapCameraAction;

    public CameraState currentState = CameraState.THIRD_PERSON;
    public UnityEvent OnThirdPersonCamActivate;
    public UnityEvent OnFirstPersonCamActivate;

    // Zoom feature
    public CinemachineThirdPersonFollow thirdPersonFollow;
    public float zoomSpeed = 0.5f;
    public float minZoom = 1f;
    public float maxZoom = 6f;

    private void Start()
    {
        swapCameraAction.Enable();
        swapCameraAction.performed += SwapCamera;
    }

    public void SwapCamera(InputAction.CallbackContext c)
    {
        if (currentState == CameraState.THIRD_PERSON)
        {
            currentState = CameraState.FIRST_PERSON;
            OnFirstPersonCamActivate?.Invoke();
            return;
        }

        currentState = CameraState.THIRD_PERSON;
        OnThirdPersonCamActivate?.Invoke();
    }

    private void LateUpdate()
    {
        HandleZoom();
    }

    private void HandleZoom()
    {
        if (currentState != CameraState.THIRD_PERSON)
            return;

        float scrollValue = Mouse.current.scroll.ReadValue().y;

        if (scrollValue != 0)
        {
            float newDistance = thirdPersonFollow.CameraDistance - scrollValue * zoomSpeed;
            newDistance = Mathf.Clamp(newDistance, minZoom, maxZoom);

            thirdPersonFollow.CameraDistance = newDistance;
        }
    }
}

public enum CameraState
{
    THIRD_PERSON,
    FIRST_PERSON
}