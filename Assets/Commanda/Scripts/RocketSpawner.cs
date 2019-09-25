using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
    public GameObject prefab;

    public void FireRocket(Command[] commands)
    {
        GameObject rocket = Instantiate(prefab, transform);
        GuidedRocket guidedRocket = rocket.GetComponent<GuidedRocket>();
        guidedRocket.Fire(commands);
    }

}
