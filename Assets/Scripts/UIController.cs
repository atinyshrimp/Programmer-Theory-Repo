using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Slider _energySlider, _funSlider, _healthSlider, _hungerSlider;
    [SerializeField] private NeedsController _needsController;
    

    // Update is called once per frame
    void Update()
    {
        _energySlider.value = _needsController.Energy;
        _funSlider.value = _needsController.Fun;
        _healthSlider.value = _needsController.Health;
        _hungerSlider.value = _needsController.Hunger;
    }
}
