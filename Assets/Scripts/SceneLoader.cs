using UnityEngine;
using UnityEngine.SceneManagement;

//I couldn't figure out how to make a player character spawn

public class SceneLoader : MonoBehaviour
{

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
