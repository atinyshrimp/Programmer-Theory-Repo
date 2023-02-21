using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Inventory/Food")]
public class Food : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
}
