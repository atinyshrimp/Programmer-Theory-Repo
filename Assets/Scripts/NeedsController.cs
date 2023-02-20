using System;
using UnityEngine;

public class NeedsController : MonoBehaviour
{
    // ENCAPSULATION
    [SerializeField] private int _fun, _energy, _hunger, _health;
    public int Fun { get { return _fun; } }
    public int Energy { get { return _energy; } }
    public int Hunger { get { return _hunger; } }
    public int Health { get { return _health; } }

    private PetManager _petManager;

    private int _funTickRate, _energyTickRate, _hungerTickRate, _healthTickRate;

    private DateTime _lastEntertained, _lastFed, _lastGainedEnergy, _lastHealthy;
    public DateTime LastEntertained { get { return _lastEntertained; } }
    public DateTime LastFed { get { return _lastFed; } }
    public DateTime LastGainedEnergy { get { return _lastGainedEnergy; } }
    public DateTime LastHealthy { get { return _lastHealthy; } }


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

        _lastEntertained = DateTime.Now;
        _lastFed = DateTime.Now;
        _lastGainedEnergy = DateTime.Now;
        _lastHealthy = DateTime.Now;
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

    public void UpdateEnergy(int amount)
    {
        if (amount > 0) _lastGainedEnergy = DateTime.Now;

        if (_energy >= 0 && _energy <= 100) _energy += amount;
        else if (_energy > 100) _energy = 100;
        else _energy = 0;
    }
    public void UpdateFun(int amount)
    {
        if (amount > 0) _lastEntertained = DateTime.Now;

        if (_fun >= 0 && _fun <= 100) _fun += amount;
        else if (_fun > 100) _fun = 100;
        else _fun = 0;
    }
    public void UpdateHealth(int amount)
    {
        if (amount > 0) _lastHealthy = DateTime.Now;

        if (_health >= 0 && _health <= 100) _health += amount;
        else if (_health > 100) _health = 100;
        else _health = 0;
    }

    public void UpdateHunger(int amount)
    {
        if (amount > 0) _lastFed = DateTime.Now;

        if (_hunger >= 0 && _hunger <= 100) _hunger += amount;
        else if (_hunger > 100) _health = 100;
        else _hunger = 0;
    }

    private void Awake()
    {
        _petManager = GetComponent<PetManager>();
        Initialize(100, 100, 100, 100, 1, 2, 5, 1);
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
        }
    }



}
