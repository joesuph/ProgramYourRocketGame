using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    [Range(1, 2)]
    public int player;

    public void PullTank()
    {
        GameObject tank = GameObject.Find("Tank" + player);
        print(tank.gameObject.name);
        if (tank != null)
            tank.transform.position = this.transform.position;
    }
}
