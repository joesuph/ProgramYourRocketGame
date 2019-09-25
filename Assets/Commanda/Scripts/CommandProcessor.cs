using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandProcessor
{
    public Command[] GetCommands(string input)
    {
        string[] lines = input.Split('\n');
        Command[] commands = new Command[lines.Length];
        for (int i = 0; i < lines.Length; i++)
        {
            string[] tokens = lines[i].Split(' ');
            bool left = false;
            if (tokens[0] == "left") left = true;
            else if (tokens[0] != "right") return null;

            float angle = float.Parse(tokens[1]);
            float time = float.Parse(tokens[2]);

            commands[i] = new Command(left, angle, time);
        }

        return commands;
    }
}
