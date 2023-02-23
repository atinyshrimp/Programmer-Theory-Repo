using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject nameScreen;
    [SerializeField] private TMP_InputField inputField;

    [SerializeField] private AudioClip cancelClip;
    [SerializeField] private AudioClip confirmClip;
    [SerializeField] private AudioClip menuSelection;
    private AudioSource audioSource;

    public void LoadNameScreen()
    {
        if (titleScreen.activeInHierarchy)
        {
            ConfirmSound();
            titleScreen.SetActive(false);
            nameScreen.SetActive(true);
        }
    }

    public void LoadTitleScreen()
    {
        if (nameScreen.activeInHierarchy)
        {
            audioSource.PlayOneShot(cancelClip, 0.8f);
            nameScreen.SetActive(false);
            titleScreen.SetActive(true);
        }
    }

    public void LoadMainScene()
    {
        inputField = GameObject.Find("InputField").GetComponent<TMP_InputField>();
        if (inputField.text != null)
        {
            ConfirmSound();
            string catName = char.ToUpper(inputField.text[0]) + inputField.text.Substring(1).ToLower();
            MainManager.instance.GetCatName(catName);

            SceneManager.LoadScene("Main");
        }
    }

    public void LoadCreditsScene()
    {
        audioSource.PlayOneShot(confirmClip, 0.8f);
        SceneManager.LoadScene("Credits");
    }

    public void Quit()
    {
        audioSource.PlayOneShot(menuSelection, 1f);
        Application.Quit();
    }

    private void Awake()
    {
        audioSource = Camera.main.GetComponent<AudioSource>();
    }

    void ConfirmSound()
    {
        audioSource.PlayOneShot(confirmClip, 0.8f);
    }
}
