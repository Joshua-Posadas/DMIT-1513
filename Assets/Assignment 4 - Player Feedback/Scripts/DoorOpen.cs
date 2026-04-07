using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour
{
    [Header("Door Movement")]
    public Transform doorDestination;
    public float moveSpeed = 2f;
    public float openDelay = 1f;

    [Header("Effects")]
    public GameObject sparkEmitter;
    public AudioSource audioSource;
    public AudioClip doorOpenSound;

    [Header("Background Audio")]
    public AudioSource backgroundAudio;
    public AudioLowPassFilter lowPassFilter;
    public float muffledVolume = 0.2f;
    public float normalVolume = 1f;

    private bool opening = false;
    private bool soundPlayed = false;

    void Update()
    {
        if (!opening || doorDestination == null)
            return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            doorDestination.position,
            moveSpeed * Time.deltaTime
        );

        if (transform.position == doorDestination.position)
        {
            opening = false;
        }
    }

    public void OpenDoor()
    {
        StartCoroutine(OpenDoorRoutine());
    }

    private IEnumerator OpenDoorRoutine()
    {
        if (sparkEmitter != null)
            sparkEmitter.SetActive(false);

        if (backgroundAudio != null)
            backgroundAudio.volume = muffledVolume;

        if (lowPassFilter != null)
            lowPassFilter.enabled = true;

        if (!soundPlayed && audioSource != null && doorOpenSound != null)
        {
            audioSource.PlayOneShot(doorOpenSound);
            soundPlayed = true;
        }

        yield return new WaitForSeconds(openDelay);
        if (backgroundAudio != null)
            backgroundAudio.volume = normalVolume;

        if (lowPassFilter != null)
            lowPassFilter.enabled = false;

        opening = true;
    }
}

