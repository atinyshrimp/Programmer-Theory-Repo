using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }
}
