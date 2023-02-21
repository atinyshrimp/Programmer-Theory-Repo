using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    [SerializeField] private List<Food> foods;
    public List<Food> Foods { get { return foods; } }

    private void Awake()
    {
        if (instance != null) return;
        instance = this;

        foods = Resources.LoadAll<Food>("Foods").ToList();
    }

    private void Start()
    {

    }
}
