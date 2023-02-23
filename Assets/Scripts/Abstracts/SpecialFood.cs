using UnityEngine;

// INHERITANCE
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Special Food")]
public class SpecialFood : Food
{
    public enum TypeOfFood { Healthy, NotHealthy }

    [SerializeField] private string _description;
    public string Description { get { return _description; } }

    [SerializeField] private TypeOfFood _typeOfFood;
    public TypeOfFood Type { get { return _typeOfFood; } }


    public override string Info()
    {
        return _description;
    }
}
