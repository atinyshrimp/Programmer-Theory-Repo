using System;
using UnityEngine;

[Serializable]
public class Pet : MonoBehaviour
{
    private DateTime lastFed, lastEntertained, lastGainedEnergy, lastHealthy;
    private int energy, fun, health, hunger;
    public int Energy { get { return energy; } }

    public Pet (DateTime lastEntertained, DateTime lastFed, DateTime lastGainedEnergy, DateTime lastHealthy,
        int energy, int fun, int health, int hunger)
    {
        this.lastEntertained = lastEntertained;
        this.lastFed = lastFed;
        this.lastGainedEnergy = lastGainedEnergy;
        this.lastHealthy = lastHealthy;

        this.energy = energy;
        this.fun = fun;
        this.health = health;
        this.hunger = hunger;
    }
}
