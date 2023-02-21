using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Food _food;
    [SerializeField] private Image _icon = null;
    public Food Food { get { return _food; } }
    private PetManager _petManager;


    public void AddFood(Food newFood)
    {
        _food = newFood;
        _icon.sprite = _food.Icon;
    }

    public void FeedCat()
    {
        _petManager.Eat(_food);
        Debug.Log($"{_food.name} was given fed to the cat");
    }

    private void Awake()
    {
        _petManager = GameObject.Find("Cat").GetComponent<PetManager>();
    }
}
