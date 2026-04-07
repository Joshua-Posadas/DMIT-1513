using UnityEngine;

public class DoorTryingToOpen : MonoBehaviour
{
    public Animator animator;
    public GameObject sparkEmitter;
    public AudioSource audioSource;
    public AudioClip doorStrainSound;

    private bool activated = false;
    private bool overridden = false;

    void Start()
    {
        ActivateDoor();
    }

    // Malfunctioning Door Behaviour
    public void ActivateDoor()
    {
        if (activated || overridden) return;
        activated = true;

        animator.Play("DoorTryingToOpen");

        if (sparkEmitter != null)
            sparkEmitter.SetActive(true);

        if (audioSource != null && doorStrainSound != null)
            audioSource.PlayOneShot(doorStrainSound);
    }

    // Door Open Behaviour
    public void OverrideOpen()
    {
        if (overridden) return;
        overridden = true;

        if (sparkEmitter != null)
            sparkEmitter.SetActive(false);

        if (animator != null)
            animator.enabled = false;
    }
}

