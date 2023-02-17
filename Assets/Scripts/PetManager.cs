using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetManager : MonoBehaviour
{
    public enum Mood { Angry, Bored, Happy, Hungry, Neutral, Scared, Sleepy, Sick }


    // ENCAPSULATION
    [SerializeField] private GameObject _emoteBubblePrefab;
    [SerializeField] private Animator _petAnimator;
    [SerializeField] private NeedsController _needsScript;
    private Mood _currentMood;
    public Mood CurrentMood
    { get { return _currentMood; } }


    // POLYMORPHISM
    void ChangeMood()
    {
        if (_needsScript.Energy < 25)
        {
            ChangeMood(Mood.Sleepy);
            _petAnimator.SetBool("isSleeping_b", true);
        }
        else _petAnimator.SetBool("isSleeping_b", false);
    }

    void ChangeMood(Mood mood)
    {
        _currentMood = mood;
    }

    // END OF POLYMORPHISM

    public static void Die()
    {

    }

    void DisplayBubble()
    {
        if (!_emoteBubblePrefab.activeInHierarchy) _emoteBubblePrefab.SetActive(true);
        else _emoteBubblePrefab.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        _petAnimator = GetComponent<Animator>();
        _needsScript = GetComponent<NeedsController>();
        _currentMood = Mood.Sick;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeMood();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ABSTRACTION
            DisplayBubble();
        }
    }

}
