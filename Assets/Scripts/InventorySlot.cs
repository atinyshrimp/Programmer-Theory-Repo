using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private Image icon;
    private Food food;

    public void AddFood(Food newFood)
    {
        food = newFood;

        icon.sprite = food.icon;
        icon.enabled = true;
    }
}
