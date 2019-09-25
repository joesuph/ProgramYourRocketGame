using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    public TextMeshProUGUI redTotal;
    public TextMeshProUGUI blueTotal;
    public TextMeshProUGUI turn;

    public void UpdateText(float _p1total, float _p2total, float _turn)
    {
        redTotal.text = _p1total.ToString("f0");
        blueTotal.text = _p2total.ToString("f0");
        turn.text = _turn.ToString("f0");
    }
}
