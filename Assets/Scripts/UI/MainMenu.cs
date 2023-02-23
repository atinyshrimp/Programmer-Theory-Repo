using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject nameScreen;
    [SerializeField] private TMP_InputField inputField;

    public void LoadNameScreen()
    {
        if (titleScreen.activeInHierarchy)
        {
            titleScreen.SetActive(false);
            nameScreen.SetActive(true);
        }
    }

    public void LoadTitleScreen()
    {
        if (nameScreen.activeInHierarchy)
        {
            nameScreen.SetActive(false);
            titleScreen.SetActive(true);
        }
    }

    public void LoadMainScene()
    {
        inputField = GameObject.Find("InputField").GetComponent<TMP_InputField>();
        if (inputField.text != null)
        {
            MainManager.instance.GetCatName(inputField.text);
            SceneManager.LoadScene("Main");
        }
    }

    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }
}
