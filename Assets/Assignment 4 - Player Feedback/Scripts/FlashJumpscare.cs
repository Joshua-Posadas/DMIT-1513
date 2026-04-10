using UnityEngine;

[RequireComponent(typeof(Collider))]
public class FlashJumpscare : MonoBehaviour
{
    public GameObject apparitionModel;
    public AudioSource audioSource;
    public AudioClip disappearSound;
    public float visibleTime = 1f;

    private bool triggered = false;

    private void Reset()
    {
        Collider col = GetComponent<Collider>();
        col.isTrigger = true;

        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 1f;
    }

    private void Start()
    {
        if (apparitionModel != null)
            apparitionModel.SetActive(false);

        if (disappearSound != null && audioSource != null)
            audioSource.clip = disappearSound;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (other.CompareTag("Vision"))
        {
            triggered = true;
            StartCoroutine(DoJumpscare());
        }
    }

    private System.Collections.IEnumerator DoJumpscare()
    {
        if (apparitionModel != null)
            apparitionModel.SetActive(true);

        if (audioSource != null)
            audioSource.Play();

        yield return new WaitForSeconds(visibleTime);
        if (apparitionModel != null)
            apparitionModel.SetActive(false);
    }
}

