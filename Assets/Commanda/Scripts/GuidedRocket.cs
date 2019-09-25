using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedRocket : MonoBehaviour
{
    public static bool isActive;

    public float speed;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CodeTank>() == null)
        {
            isActive = false;
            CameraManager.instance.ReturnToOriginalParent();
            Destroy(gameObject);
        }
    }

    public void Fire(Command[] commands)
    {
        StartCoroutine(followCommands(commands));
    }

    IEnumerator followCommands(Command[] commands)
    {
        if (commands == null)
            throw new System.NullReferenceException();

        if (commands.Length < 1)
            yield break;

        isActive = true;
        CameraManager.instance.StartFollowing(this.transform);

        rb.velocity = commands[0].left ? Vector2.left * speed : Vector2.right * speed;
        rb.velocity = Rotate(rb.velocity, commands[0].left ? -commands[0].angle : commands[0].angle);
        transform.localEulerAngles += new Vector3(0, 0, commands[0].left ? commands[0].angle : -commands[0].angle);
        float fireTime = Time.time;

        while (Time.time < fireTime + commands[0].time)
            yield return null;

        for (int i = 1; i < commands.Length; i++)
        {
            float timeAtCommand = Time.time;
            rb.velocity = Rotate(rb.velocity, commands[i].left ? commands[i].angle : -commands[i].angle);
            transform.localEulerAngles += new Vector3(0, 0, commands[i].left ? commands[i].angle : -commands[i].angle);
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
        commands[0] = new Command(false, 10, 3f);
        commands[1] = new Command(true, 50, .7f);
        commands[2] = new Command(false, 45, 2f);

        return commands;
    }
}
