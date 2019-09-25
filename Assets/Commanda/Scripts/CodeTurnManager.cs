using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CodeTurnManager : MonoBehaviour
{
    public CodeTank tank1;
    public CodeTank tank2;

    public Canvas TurnWaitingCanvas;
    public TextMeshProUGUI turnWaitingText;

    public Canvas terminalCanvas;

    public TimerUI timers;

    [Range(10, 30)]
    public float turnTimer;
    [Range(60, 180)]
    public float gameTimer;

    private CodeTank currentPlayer;


    // pan to player
    // 5 seconds or press any button
    // start elapsing tank time
    // show terminal
    // wait for submit or end of turn

    // repeat for next player

    private void Start()
    {
        tank1.timeRemaining = gameTimer;
        tank2.timeRemaining = gameTimer;

        SelectFirstPlayer();
        StartTurn();
    }

    void SelectFirstPlayer()
    {
        currentPlayer = tank1;
    }

    void StartTurn()
    {
        StartCoroutine(Turn());
    }
    void SwapTurn()
    {
        if (currentPlayer == tank1)
            currentPlayer = tank2;
        else
            currentPlayer = tank1;

        tank1.hasSubmitted = tank2.hasSubmitted = false;
        tank1.isAwaitingInput = tank2.isAwaitingInput = false;

        GameObject.Find("TerminalInput").GetComponent<TMP_InputField>().text = "";

        StartTurn();
    }

    IEnumerator Turn()
    {
        CameraManager.instance.PanTo(currentPlayer.transform.position);

        // 5 second to press any button
        TurnWaitingCanvas.enabled = true;
        float waitTime = 5f;
        float startWait = Time.time;
        while (Time.time < startWait + waitTime && !Input.anyKeyDown)
        {
            turnWaitingText.text = "Press any button to continue... " + (5 - (Time.time - startWait)).ToString("f0");
            yield return null;
        }
        TurnWaitingCanvas.enabled = false;

        // SHOW TERMINAL
        terminalCanvas.enabled = true;

        currentPlayer.isAwaitingInput = true;

        // start turn timer
        float turn = turnTimer;
        while (turn >= 0 && !currentPlayer.hasSubmitted)
        {
            currentPlayer.timeRemaining -= Time.deltaTime;
            turn -= Time.deltaTime;

            // update timers text
            timers.UpdateText(tank1.timeRemaining, tank2.timeRemaining, turn);
            yield return null;
        }

        terminalCanvas.enabled = false;

        while (GuidedRocket.isActive)
            yield return null;

        SwapTurn();
    }
}
