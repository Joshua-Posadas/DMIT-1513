using UnityEngine;

public class EndScript : MonoBehaviour
{
    public PauseController pauseController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Vision"))
        {
            pauseController.Quit();
        }
    }
}
