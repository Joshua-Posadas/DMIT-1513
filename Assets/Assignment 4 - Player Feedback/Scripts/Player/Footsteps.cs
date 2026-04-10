using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Footsteps : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip footstepClip;

    [Header("Settings")]
    public float stepInterval = 0.5f;
    public float minSpeed = 0.2f;

    private CharacterController controller;
    private Movement movementScript;
    private float stepTimer;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        movementScript = GetComponent<Movement>();
    }

    private void Update()
    {
        float speed = movementScript != null
            ? movementScript.GetCurrentSpeed()
            : 0f;

        bool isWalking = controller.isGrounded && speed > minSpeed;

        if (!isWalking)
        {
            stepTimer = stepInterval;
            return;
        }

        stepTimer -= Time.deltaTime;

        if (stepTimer <= 0f)
        {
            PlayFootstep();
            stepTimer = stepInterval;
        }
    }

    private void PlayFootstep()
    {
        if (footstepClip == null) return;
        audioSource.PlayOneShot(footstepClip);
    }
}

