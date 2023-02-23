using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Inventory/Food")]
public class Food : ScriptableObject
{
    new public string name = "New Item";

    // ENCAPSULATION
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _energy;
    [SerializeField] private int _fun;
    [SerializeField] private int _health;
    [SerializeField] private int _hunger;
    [SerializeField] private UIController _controller;

    public Sprite Icon { get { return _icon; } }
    public int Energy { get { return _energy; } }
    public int Fun { get { return _fun; } }
    public int Health { get { return _health; } }
    public int Hunger { get { return _hunger; } }

    public virtual string Info()
    {
        return $"{name} was fed to the cat";
/*        _controller.DisplayFoodInfo(this);
        descriptionText = UIController.descriptionBox.GetComponentInChildren<TMP_Text>();
        descriptionText.text = $"{name} was fed to the cat";
*/    }
}
