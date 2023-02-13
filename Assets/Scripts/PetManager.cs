using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetManager : MonoBehaviour
{
    public enum Mood { Angry, Bored, Happy, Hungry, Neutral, Scared, Sleepy, Sick }


    // ENCAPSULATION
    [SerializeField] private GameObject _emoteBubblePrefab;
    private Mood _currentMood;
    public Mood CurrentMood
    { get { return _currentMood; } }


    void DisplayBubble()
    {
        if (!_emoteBubblePrefab.activeInHierarchy) _emoteBubblePrefab.SetActive(true);
        else _emoteBubblePrefab.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentMood = Mood.Sick;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //ABSTRACTION
            DisplayBubble();
        }
    }
}
