using UnityEngine;

public class AppearOnTrigger : MonoBehaviour
{
    public GameObject modelToAppear;
    private bool hasAppeared = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasAppeared) return;

        if (other.CompareTag("Player"))
        {
            modelToAppear.SetActive(true);
            hasAppeared = true;
        }
    }
}
