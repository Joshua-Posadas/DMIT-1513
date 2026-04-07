using UnityEngine;

public class DoorButton : MonoBehaviour, IInteractable
{
    [Header("Door Scripts")]
    public DoorOpen door;
    public DoorTryingToOpen malfunction;

    public void Interact()
    {
        if (malfunction != null)
            malfunction.OverrideOpen();

        if (door != null)
            door.OpenDoor();
    }
}
