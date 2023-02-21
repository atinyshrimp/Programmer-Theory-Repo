using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // ENCAPSULATION
    [SerializeField] private Transform _foodsParent;
    [SerializeField] private GameObject _slotPrefab;

    private Inventory _inventory;
    private InventorySlot[] _slots;

    private void Awake()
    {
        _inventory = Inventory.instance;
        _slots = new InventorySlot[_inventory.Foods.Count];

        for (int i = 0; i < _inventory.Foods.Count; i++)
            Instantiate(_slotPrefab, _foodsParent);

        _slots = _foodsParent.GetComponentsInChildren<InventorySlot>();

        int j = 0;
        foreach (Food food in _inventory.Foods)
        {
            _slots[j].AddFood(_inventory.Foods[j]);
            j++;
        }
        
    }
}
