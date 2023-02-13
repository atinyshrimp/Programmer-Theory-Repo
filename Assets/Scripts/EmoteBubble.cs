using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmoteBubble : MonoBehaviour
{
    // ENCAPSULATION
    [SerializeField] private Sprite angryIconSprite;
    [SerializeField] private Sprite boredIconSprite;
    [SerializeField] private Sprite happyIconSprite;
    [SerializeField] private Sprite hungryIconSprite;
    [SerializeField] private Sprite sickIconSprite;
    [SerializeField] private Sprite scaredIconSprite;
    [SerializeField] private Sprite sleepyIconSprite;


    private SpriteRenderer bubbleSprite;
    private SpriteRenderer iconSprite;
    private PetManager pet;

    private void Awake()
    {
        bubbleSprite = transform.Find("Bubble").GetComponent<SpriteRenderer>();
        iconSprite = transform.Find("Icon").GetComponent<SpriteRenderer>();
        pet = transform.parent.GetComponent<PetManager>();
    }

    private void Start()
    {
        bubbleSprite.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
        iconSprite.transform.Translate(new Vector3(0, 0.05f, 0));
        iconSprite.transform.localScale = new Vector3(1.75f, 1.75f, 1.75f);

        // ABSTRACTION
        Setup();
    }

    private void Setup()
    {
        iconSprite.sprite = GetIconSprite(pet.CurrentMood);
    }

    private Sprite GetIconSprite(PetManager.Mood iconType)
    {
        switch (iconType)
        {
            default:
            case PetManager.Mood.Angry:     return angryIconSprite;
            case PetManager.Mood.Bored:     return boredIconSprite;
            case PetManager.Mood.Happy:     return happyIconSprite;
            case PetManager.Mood.Hungry:    return hungryIconSprite;
            case PetManager.Mood.Scared:    return scaredIconSprite;
            case PetManager.Mood.Sleepy:    return scaredIconSprite;
            case PetManager.Mood.Sick:      return sickIconSprite;
        }
    }
}
