using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // ENCAPSULATION
    private static float gameHourTimer;
    public static float GameHourTimer { get { return gameHourTimer; } }
    public float hourLength;


    // Update is called once per frame
    void Update()
    {
        if (gameHourTimer <= 0)
            gameHourTimer = hourLength;
        else gameHourTimer -= Time.deltaTime;
    }
}
