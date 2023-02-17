using System;
using UnityEngine;

public class NeedsController : MonoBehaviour
{
    // ENCAPSULATION
    [SerializeField] private int fun, energy, hunger, health;
    public int Fun { get { return fun; } }
    public int Energy { get { return energy; } }
    public int Hunger { get { return hunger; } }
    public int Health { get { return health; } }

    private int funTickRate, energyTickRate, hungerTickRate, healthTickRate;

    private DateTime lastEntertained, lastFed, lastGainedEnergy, lastHealthy;
    public DateTime LastEntertained { get { return lastEntertained; } }
    public DateTime LastFed { get { return lastFed; } }
    public DateTime LastGainedEnergy { get { return lastGainedEnergy; } }
    public DateTime LastHealthy { get { return lastHealthy; } }


    public void Initialize(int energy, int fun, int health, int hunger,
        int funTickRate, int energyTickRate, int hungerTickRate, int healthTickRate)
    {
        this.energy = energy;
        this.fun = fun;
        this.health = health;
        this.hunger = hunger;

        this.energyTickRate = energyTickRate;
        this.funTickRate = funTickRate;
        this.healthTickRate = healthTickRate;
        this.hungerTickRate = hungerTickRate;

        lastEntertained = DateTime.Now;
        lastFed = DateTime.Now;
        lastGainedEnergy = DateTime.Now;
        lastHealthy = DateTime.Now;
    }

    private void Awake()
    {
        Initialize(100, 100, 100, 100, 8, 3, 5, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.GameHourTimer < 0)
        {
            updateEnergy(-energyTickRate);
            updateFun(-funTickRate);
            updateHealth(-healthTickRate);
            updateHunger(-hungerTickRate);
        }
    }


    public void updateEnergy(int amount)
    {
        if (amount > 0) lastGainedEnergy = DateTime.Now;

        if (energy > 0 && energy <= 100)
            energy += amount;
    }
    public void updateFun(int amount)
    {
        if (amount > 0) lastEntertained = DateTime.Now;

        if (fun > 0 && fun <= 100)
            fun += amount;
    }
    public void updateHealth(int amount)
    {
        if (amount > 0) lastHealthy = DateTime.Now;

        if (health > 0 && health <= 100)
            health += amount;
        else if (health > 100)
            health = 100;
        else PetManager.Die();
    }

    public void updateHunger(int amount)
    {
        if (amount > 0) lastFed = DateTime.Now;

        if (hunger > 0 && hunger <= 100)
            hunger += amount;
    }

}
