using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    public float interactDistance = 3f;

    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            int mask = ~LayerMask.GetMask("Player");

            if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, mask))
            {
                var interactable = hit.collider.GetComponent<IInteractable>();

                if (interactable != null)
                    interactable.Interact();
            }
        }
    }
}
