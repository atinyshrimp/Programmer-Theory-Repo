using System;
using UnityEngine;

public class NeedsController : MonoBehaviour
{
    #region Attributes

    // ENCAPSULATION
    [SerializeField] private int _fun, _energy, _hunger, _health;
    public int Fun { get { return _fun; } }
    public int Energy { get { return _energy; } }
    public int Hunger { get { return _hunger; } }
    public int Health { get { return _health; } }

    private PetManager _petManager;

    private int _funTickRate, _energyTickRate, _hungerTickRate, _healthTickRate;

    #endregion

    public void Initialize(int energy, int fun, int health, int hunger,
        int energyTickRate, int funTickRate, int hungerTickRate, int healthTickRate)
    {
        _energy = energy;
        _fun = fun;
        _health = health;
        _hunger = hunger;

        _energyTickRate = energyTickRate;
        _funTickRate = funTickRate;
        _healthTickRate = healthTickRate;
        _hungerTickRate = hungerTickRate;
    }

    public void ChangeTickRate(string mode)
    {
        switch (mode)
        {
            case "energy":
                if (_petManager.PetAnimator.GetBool("isSleeping_b"))
                    _energyTickRate = -8;
                else _energyTickRate = 1;
                break;
            case "fun":
                _funTickRate = -_funTickRate;
                break;
            case "health":
                _healthTickRate = -_healthTickRate;
                break;
            case "hunger":
                _hungerTickRate = -_hungerTickRate;
                break;
        }
    }

    public void GetEffects(Food food)
    {
        // ABSTRACTION
        UpdateEnergy(food.Energy);
        UpdateFun(food.Fun);
        UpdateHealth(food.Health);
        UpdateHunger(food.Hunger);
    }

    private void UpdateEnergy(int amount)
    {
        if (_energy > 100) _energy = 100;
        else if (_energy < 0) _energy = 0;
        else _energy += amount;
    }

    private void UpdateFun(int amount)
    {
        if (_fun > 100) _fun = 100;
        else if (_fun < 0) _fun = 0;
        else _fun += amount;
    }
        
    private void UpdateHealth(int amount)
    {
        if (_health > 100) _health = 100;
        else if (_health < 0) _health = 0;
        else _health += amount;
    }

    private void UpdateHunger(int amount)
    {
        if (_hunger > 100) _hunger = 100;
        else if (_hunger < 0) _hunger = 0;
        else _hunger += amount;
    }

    private void Awake()
    {
        _petManager = GetComponent<PetManager>();
        MainManager mainManager = MainManager.instance;
        if (mainManager.LoadPet()) Initialize(mainManager.CurrentPet.energy, mainManager.CurrentPet.fun, mainManager.CurrentPet.health, mainManager.CurrentPet.hunger,
                                                1, 2, 5, 1);
        else Initialize(100, 100, 75, 100, 1, 2, 5, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.GameHourTimer < 0)
        {
            UpdateEnergy(-_energyTickRate);
            UpdateFun(-_funTickRate);
            UpdateHealth(-_healthTickRate);
            UpdateHunger(-_hungerTickRate);

            MainManager.instance.SavePet();
        }
    }
}
