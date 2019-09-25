using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    private float z;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        z = transform.localPosition.z;
    }

    public void PanTo(Vector2 position)
    {
        StartCoroutine(Pan(position));
    }
    IEnumerator Pan(Vector2 position)
    {
        float transitionLegth = .5f;

        float startTime = Time.time;
        Vector2 startPosition = Camera.main.transform.position;

        while (Time.time < startTime + transitionLegth)
        {
            float ratio = (Time.time - startTime) / transitionLegth;
            Camera.main.transform.position = Vector3.Lerp(startPosition, position, ratio) + Vector3.back;
            yield return null;
        }
    }

    public void ChildTo(Transform parent)
    {
        Camera.main.transform.parent = parent;
    }

    public void StartFollowing(Transform parent)
    {
        StartCoroutine(Follow(parent));
    }

    IEnumerator Follow(Transform parent)
    {
        while (true)
        {
            Camera.main.transform.position = parent.position + Vector3.back;
            yield return null;
        }
    }

    public void ReturnToOriginalParent()
    {
        StopAllCoroutines();
        Camera.main.transform.parent = this.transform;
    }
}
