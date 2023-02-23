using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Slider _energySlider, _funSlider, _healthSlider, _hungerSlider;
    [SerializeField] private PetManager _petManager;
    [SerializeField] private GameObject _inventory;
    [SerializeField] private GameObject descriptionBox;

    [SerializeField] private AudioClip _openMenu;
    [SerializeField] private AudioClip _closeMenu;
    [SerializeField] private AudioClip _menuSelection;

    private NeedsController _needsController;
    [SerializeField] private AudioSource _audioSource;

    public void DisplayFoodInfo(Food food)
    {
        Image descriptionBg = descriptionBox.GetComponent<Image>();
        TMP_Text descriptionText = descriptionBox.GetComponentInChildren<TMP_Text>();
        if (food.GetType() == typeof(SpecialFood))
        {
            SpecialFood specialFood = (SpecialFood)food; 
            if (specialFood.Type == SpecialFood.TypeOfFood.NotHealthy)
            {
                descriptionBg.color = new Color(2.55f, 2.06f, 2.03f, 0.87f);
                descriptionText.color = new Color(1.38f, 0.05f, 0, 2.55f);
            }
            else { HealthyFoodBox(descriptionBg, descriptionText); }
        } // ABSTRACTION
        else { HealthyFoodBox(descriptionBg, descriptionText); }

        descriptionText.text = food.Info();
        descriptionBox.SetActive(true);
        StartCoroutine(CloseDescriptionBox());
    }

    public void DisplayInfo(string mode="sleeping")
    {
        Image descriptionBg = descriptionBox.GetComponent<Image>();
        TMP_Text descriptionText = descriptionBox.GetComponentInChildren<TMP_Text>();
        descriptionBg.color = Color.white;
        descriptionText.color = Color.black;
        
        switch (mode)
        {
            case "sleeping":
                descriptionText.text = "Your cat is sleeping, you can't feed it..";
                break;
            case "full":
                descriptionText.text = $"{MainManager.instance.PetName} is full, wait a little bit before trying to feed it again :)";
                break;
        }

        if (mode == "sleeping")
        {
        }
        descriptionBox.SetActive(true);
        StartCoroutine (CloseDescriptionBox());
    }

    public void Quit()
    {
        _audioSource.PlayOneShot(_menuSelection, 1f);
        Application.Quit();
    }

    public void Sleep()
    {
        _audioSource.PlayOneShot(_menuSelection, 1f);
        _petManager.Sleep();
        _needsController.ChangeTickRate("energy");
    }

    public void ToggleInventory()
    {
        if (_inventory.activeInHierarchy)
        {
            _audioSource.PlayOneShot(_closeMenu, 1f);
            _inventory.SetActive(false);
        }
        else
        {
            _audioSource.PlayOneShot(_openMenu, 1f);
            _inventory.SetActive(true);
        }
    }

    private void Awake()
    {
        _needsController = _petManager.GetComponent<NeedsController>();
        _audioSource = Camera.main.GetComponent<AudioSource>();        
    }

    IEnumerator CloseDescriptionBox()
    {
        yield return new WaitForSeconds(5);
        descriptionBox.SetActive(false);
    }

    private void HealthyFoodBox(Image bg, TMP_Text text)
    {
        bg.color = new Color(2.23f, 2.55f, 1.74f, 0.87f);
        text.color = new Color(0.16f, 0.97f, 0, 2.55f);
        text.faceColor = new Color(0.16f, 0.97f, 0, 2.55f);
    }

    // Update is called once per frame
    void Update()
    {
        _energySlider.value = _needsController.Energy;
        _funSlider.value = _needsController.Fun;
        _healthSlider.value = _needsController.Health;
        _hungerSlider.value = _needsController.Hunger;
    }
}
