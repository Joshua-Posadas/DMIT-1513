using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseController : MonoBehaviour
{
    public GameObject pauseMenuUI;

    public PlayerRotation playerRotation;
    public Movement playerMovement;
    public PlayerInteract playerInteract;

    private bool isPaused = false;
    private InputAction pauseAction = new InputAction(binding: "<Keyboard>/escape");

    void OnEnable()
    {
        pauseAction.performed += TogglePause;
        pauseAction.Enable();
    }

    void OnDisable()
    {
        pauseAction.Disable();
    }

    private void TogglePause(InputAction.CallbackContext ctx)
    {
        if (isPaused)
            Continue();
        else
            Pause();
    }

    public void Pause()
    {
        isPaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 1f;

        if (playerInteract != null)
            playerInteract.enabled = false;

        if (playerRotation != null)
            playerRotation.rotationInput.Disable();

        if (playerMovement != null)
            playerMovement.movementInput.Disable();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Continue()
    {
        isPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;

        if (playerInteract != null)
            playerInteract.enabled = true;

        if (playerRotation != null)
            playerRotation.rotationInput.Enable();

        if (playerMovement != null)
            playerMovement.movementInput.Enable();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Return()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Assignment 4 Main Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
