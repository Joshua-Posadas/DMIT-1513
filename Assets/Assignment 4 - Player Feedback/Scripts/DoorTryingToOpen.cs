using UnityEngine;

public class DoorTryingToOpen : MonoBehaviour
{
    public Animator animator;
    public GameObject sparkEmitter;
    public AudioSource audioSource;
    public AudioClip doorStrainSound;

    private bool activated = false;
    void Start()
    {
        ActivateDoor();
    }

    public void ActivateDoor()
    {
        if (activated) return;
        activated = true;
        animator.Play("DoorTryingToOpen");

        if (sparkEmitter != null)
            sparkEmitter.SetActive(true);

        if (audioSource != null && doorStrainSound != null)
            audioSource.PlayOneShot(doorStrainSound);
    }
}

