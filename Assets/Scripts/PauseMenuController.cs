using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private InputAction pauseAction = new InputAction(binding: "<Keyboard>/escape");

    void OnEnable()
    {
        pauseAction.performed += PauseMenu;
        pauseAction.Enable();
    }

    void OnDisable()
    {
        pauseAction.Disable();
    }

    private void PauseMenu(InputAction.CallbackContext ctx)
    {
        pauseMenuUI.SetActive(true);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
    }

    public void Return()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
