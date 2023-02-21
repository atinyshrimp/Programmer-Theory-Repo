using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Food food;
    public Food Food { get { return food; } }
    [SerializeField] private Image icon;
    [SerializeField] private PetManager _petManager;


    public void AddFood(Food newFood)
    {
        food = newFood;
        icon.sprite = food.Icon;
        icon.enabled = true;
    }

    public void FeedCat()
    {
        _petManager.Eat(food);
        Debug.Log($"{food.name} was given to eat to the cat");
    }

    private void Awake()
    {
        _petManager = GameObject.Find("Cat").GetComponent<PetManager>();
    }
}
