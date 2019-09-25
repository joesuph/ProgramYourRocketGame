using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeTank : MonoBehaviour
{
    [Range(1, 2)]
    public int player;

    public RocketSpawner spawner;

    [HideInInspector]
    public float timeRemaining;
    [HideInInspector]
    public bool hasSubmitted = false;
    [HideInInspector]
    public bool isAwaitingInput = false;

    public void SubmitCommands(Command[] commands)
    {
        hasSubmitted = true;
        isAwaitingInput = false;

        spawner.FireRocket(commands);
    }
}
