using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Transform foodsParent;
    Inventory inventory;
    InventorySlot[] slots;

    private void Start()
    {
        inventory = Inventory.instance;
    }
}
