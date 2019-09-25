using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalToggler : MonoBehaviour
{
    private Canvas terminal;

    private void Awake()
    {
        terminal = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
