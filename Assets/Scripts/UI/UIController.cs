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

    // maybe just take the NeedsController from the PetManager ?? it works :)
    private NeedsController _needsController;

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
        TMP_Text descriptionText = descriptionBox.GetComponentInChildren<TMP_Text>();
        if (mode == "sleeping")
        {
            descriptionText.text = "Your cat is sleeping, you can't feed it..";

        }
        descriptionBox.SetActive(true);
        StartCoroutine (CloseDescriptionBox());
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Sleep()
    {
        _petManager.Sleep();
        _needsController.ChangeTickRate("energy");
    }

    public void ToggleInventory()
    {
        if (_inventory.activeInHierarchy) _inventory.SetActive(false);
        else _inventory.SetActive(true);
    }

    private void Awake()
    {
        _needsController = _petManager.GetComponent<NeedsController>();
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
