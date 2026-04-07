using UnityEngine;

public class DisappearWhenSeen : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip disappearSound;

    private bool hasDisappeared = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasDisappeared) return;

        if (other.CompareTag("Vision"))
        {
            hasDisappeared = true;

            if (audioSource != null && disappearSound != null)
                audioSource.PlayOneShot(disappearSound);

            gameObject.SetActive(false);
        }
    }
}
