using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainLoader : MonoBehaviour
{
    public GameObject[] terrainSets;

    private void Start()
    {
        System.Random rand = new System.Random();
        // Load(rand.Next(0, 3));
        Load(0);
    }

    private void Load(int index)
    {
        if (index >= terrainSets.Length || index < 0)
            return;

        for (int i = 0; i < terrainSets.Length; i++)
        {
            if (i == index)
            {
                terrainSets[i].SetActive(true);
                StartPoint[] points = terrainSets[i].GetComponentsInChildren<StartPoint>();
                print(points.Length);

                points[0].PullTank();
                points[1].PullTank();
            }
            else
                terrainSets[i].SetActive(false);
        }
    }
}
