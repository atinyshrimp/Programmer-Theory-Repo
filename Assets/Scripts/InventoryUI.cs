using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // ENCAPSULATION
    [SerializeField] private Transform foodsParent;
    [SerializeField] private GameObject slotPrefab;

    private Inventory inventory;
    private InventorySlot[] slots;

    private void Start()
    {
        inventory = Inventory.instance;
        slots = new InventorySlot[inventory.Foods.Count];

        for (int i = 0; i < inventory.Foods.Count; i++)
            Instantiate(slotPrefab, foodsParent);

        slots = foodsParent.GetComponentsInChildren<InventorySlot>();

        int j = 0;
        foreach (Food food in inventory.Foods)
        {
            slots[j].AddFood(food);
            j++;
        }
    }

    private void Update()
    {
    }
}
