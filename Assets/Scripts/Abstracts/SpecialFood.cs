using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// INHERITANCE
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Special Food")]
public class SpecialFood : Food
{
    [SerializeField] private string _description;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
