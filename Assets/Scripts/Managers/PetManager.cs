using UnityEngine;

public class PetManager : MonoBehaviour
{
    public enum Mood { Angry, Bored, Happy, Hungry, Neutral, Scared, Sleepy, Sick }


    // ENCAPSULATION
    [SerializeField] private GameObject _emoteBubblePrefab;

    private Animator _petAnimator;
    public Animator PetAnimator { get { return _petAnimator; } }

    private NeedsController _needsScript;

    private Mood _currentMood;
    public Mood CurrentMood
    { get { return _currentMood; } }

    public void Eat(Food food)
    {
        _needsScript.GetEffects(food);
    }

    public void Sleep()
    {
        if (!_petAnimator.GetBool("isSleeping_b"))
            _petAnimator.SetBool("isSleeping_b", true);
        else _petAnimator.SetBool("isSleeping_b", false);
    }

    private void OnMouseDown()
    {
        _emoteBubblePrefab.SetActive(true);        
    }

    private void OnMouseExit()
    {
        _emoteBubblePrefab.SetActive(false);        
    }

    // POLYMORPHISM
    void ChangeMood()
    {
        if (_needsScript.Energy < 25) ChangeMood(Mood.Sleepy);
        else ChangeMood(Mood.Neutral);
        if (_needsScript.Fun < 40) ChangeMood(Mood.Bored);
        else ChangeMood(Mood.Neutral);
        if (_needsScript.Health < 20) ChangeMood(Mood.Sick);
        else ChangeMood(Mood.Neutral);
        if (_needsScript.Hunger < 35) ChangeMood(Mood.Hungry);
        else ChangeMood(Mood.Neutral);
    }

    void ChangeMood(Mood mood)
    {
        _currentMood = mood;
    }

    // end of POLYMORPHISM

    public static void Die()
    {

    }

/*    void DisplayBubble()
    {
        if (!_emoteBubblePrefab.activeInHierarchy) _emoteBubblePrefab.SetActive(true);
        else _emoteBubblePrefab.SetActive(false);
    }
*/
    // Start is called before the first frame update
    void Start()
    {
        _petAnimator = GetComponent<Animator>();
        _needsScript = GetComponent<NeedsController>();
        _currentMood = Mood.Neutral;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeMood();
/*        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ABSTRACTION
            DisplayBubble();
        }
*/    }
}
