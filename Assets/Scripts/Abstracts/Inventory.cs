using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    // ENCAPSULATION
    [SerializeField] private List<Food> _foods;
    public List<Food> Foods { get { return _foods; } }


    private void Awake()
    {
        if (instance != null) return;
        instance = this;

        _foods = Resources.LoadAll<Food>("Foods").ToList();
    }
}
