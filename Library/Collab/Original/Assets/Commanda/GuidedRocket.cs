using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedRocket : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void Start()
    {
        StartCoroutine(followCommands(SampleCommands()));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }

    public void Fire()
    {
        // StartCoroutine(followCommands)
    }

    IEnumerator followCommands(Command[] commands)
    {
        if (commands == null)
            throw new System.NullReferenceException();

        if (commands.Length < 1)
            yield break;

        rb.velocity = commands[0].left ? Vector2.left * speed : Vector2.right * speed;
        rb.velocity = Rotate(rb.velocity, commands[0].angle);
        float fireTime = Time.time;

        while (Time.time < fireTime + commands[0].time)
            yield return null;

        for (int i = 1; i < commands.Length; i++)
        {
            float timeAtCommand = Time.time;
            rb.velocity = Rotate(rb.velocity, commands[i].left ? commands[i].angle : -commands[i].angle);
            while (Time.time < timeAtCommand + commands[i].time)
                yield return null;
        }
    }

    //https://answers.unity.com/questions/661383/whats-the-most-efficient-way-to-rotate-a-vector2-o.html
    private static Vector2 Rotate(Vector2 v, float degrees)
    {
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

        float tx = v.x;
        float ty = v.y;
        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);
        return v;
    }

    private static Command[] SampleCommands()
    {
        Command[] commands = new Command[3];
        commands[0] = new Command(false, 10, 2f);
        commands[1] = new Command(true, 90, 1f);
        commands[2] = new Command(false, 90, 1f);

        return commands;
    }
}
