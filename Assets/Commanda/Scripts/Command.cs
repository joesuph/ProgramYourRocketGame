using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command
{
    public bool left; // false = right
    public float angle; // degrees
    public float time; // seconds

    public Command(bool _left, float _angle, float _time)
    {
        left = _left;
        angle = _angle;
        time = _time;
    }

    public override string ToString()
    {
        return left ? "Left " : "Right " + angle + " degrees " + time + " seconds";
    }
}
