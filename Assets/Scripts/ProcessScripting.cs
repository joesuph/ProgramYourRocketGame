using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ProcessScripting : MonoBehaviour
{
    public TMP_InputField input;
    public CodeTank tank1;
    public CodeTank tank2;

    public void useCode()
    {
        print("Submitting:\r\n" + input.text);



        Command[] c = getCommands();

        if (c != null)
        {
            if (tank1.isAwaitingInput)
                tank1.SubmitCommands(c);
            else
                tank2.SubmitCommands(c);
        }
        else
        {
            print("Invalid commands");
        }
    }


    private Command[] getCommands()
    {
        try
        {
            List<Command> commands = new List<Command>();
            string code = input.text.ToString();
            string[] lines = code.Split(new string[] { "\n" }, StringSplitOptions.None);

            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].Trim();
                List<string> tokens = new List<string>(lines[i].Split(' '));
                for (int j = 0; j < tokens.Count; j += 3)
                    commands.Add(new Command(tokens[j] == "left", float.Parse(tokens[j + 1]), float.Parse(tokens[j + 2])));
            }

            return commands.ToArray();
        }
        catch
        {
            return null;
        }
    }
}