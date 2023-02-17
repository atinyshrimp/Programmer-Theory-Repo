using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedsController : MonoBehaviour
{
    // ENCAPSULATION
    [SerializeField] private int fun, energy, hunger, health;
    [SerializeField] private int funTickRate, energyTickRate, hungerTickRate, healthTickRate;
    public int Fun { get { return fun; } }
    public int Energy { get { return energy; } }
    public int Hunger { get { return hunger; } }
    public int Health { get { return health; } }

    public void Initialize(int energy, int fun, int health, int hunger)
    {
        this.energy = energy;
        this.fun = fun;
        this.health = health;
        this.hunger = hunger;
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
        if (energy > 0 && energy <= 100)
            energy += amount;
    }
    public void updateFun(int amount)
    {
        if (fun > 0 && fun <= 100)
            fun += amount;
    }
    public void updateHealth(int amount)
    {
        if (health > 0 && health <= 100)
            health += amount;
        else if (health > 100)
            health = 100;
        else PetManager.Die();
    }

    public void updateHunger(int amount)
    {
        if (hunger > 0 && hunger <= 100)
            hunger += amount;
    }

}
