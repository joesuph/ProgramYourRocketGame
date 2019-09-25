using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnManager : MonoBehaviour
{
    public TimerUI timer;
    public Tank p1Tank;
    public Tank p2Tank;

    [Range(10, 60)]
    public float turnSeconds;
    [Range(60, 300)]
    public float gameSeconds;

    private float currentSecondsLeft;

    private void Start()
    {
        p1Tank.isAcceptingInput = true;
        p1Tank.timeRemaining = p2Tank.timeRemaining = gameSeconds;
        StartTurn();
    }

    void SwapTurn()
    {
        p1Tank.isAcceptingInput = !p1Tank.isAcceptingInput;
        p2Tank.isAcceptingInput = !p2Tank.isAcceptingInput;

        GameObject.Find("TerminalInput").GetComponent<TMP_InputField>().text = "";

        StartTurn();
    }

    void StartTurn()
    {
        StartCoroutine(HandleTimer());
    }

    IEnumerator HandleTimer()
    {
        currentSecondsLeft = turnSeconds;
        while (currentSecondsLeft > 0)
        {
            currentSecondsLeft -= Time.deltaTime;
            if (p1Tank.isAcceptingInput)
                p1Tank.timeRemaining -= Time.deltaTime;
            else
                p2Tank.timeRemaining -= Time.deltaTime;

            timer.UpdateText(p1Tank.timeRemaining, p2Tank.timeRemaining, currentSecondsLeft);

            string tankDescription;
            if (p1Tank.isAcceptingInput)
                tankDescription = "Red Tank: ";
            else
                tankDescription = "Blue Tank: ";

            print(tankDescription + currentSecondsLeft + " / " + turnSeconds);
            yield return null;
        }
        SwapTurn();
    }
}
