using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    // ENCAPSULATION
    [SerializeField] private Image _icon = null;
    private UIController _controller;
    private PetManager _petManager;

    private Food _food;
    public Food Food { get { return _food; } }


    public void AddFood(Food newFood)
    {
        _food = newFood;
        _icon.sprite = _food.Icon;
    }

    public void FeedCat()
    {
        // you can only feed the cat if the latter is not sleeping
        if (!_petManager.PetAnimator.GetBool("isSleeping_b"))
        {
            _petManager.Eat(_food);
            _controller.DisplayFoodInfo(_food);
            Debug.Log($"{_food.name} was given fed to the cat");
        }
        else
        {
            _controller.DisplayInfo();
            Debug.Log("The cat is sleeping, you can't feed it");
        }

    }

    private void Awake()
    {
        _petManager = GameObject.Find("Cat").GetComponent<PetManager>();
        _controller = GameObject.Find("Game UI").GetComponent<UIController>();
    }
}
