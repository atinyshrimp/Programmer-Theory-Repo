using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    [SerializeField] private GameObject slotPrefab;

    private void Awake()
    {
        if (instance != null) return;
        instance = this;
    }

    private void Start()
    {
        // Instantiate(slotPrefab,);
    }

    public List<Food> foods = new List<Food>();

    public void Add (Food food)
    {
        foods.Add(food);
    }

    public void Remove(Food food)
    {
        foods.Remove(food);
    }
}
