using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Food food;
    [SerializeField] private Image icon;


    public void AddFood(Food newFood)
    {
        food = newFood;
        icon.sprite = food.icon;
        icon.enabled = true;
    }

}
