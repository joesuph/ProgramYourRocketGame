using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    private Rigidbody2D rb;

    [Range(1, 50)]
    public float speed;

    private Vector3 input;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        float x = 0;

        if (Input.GetKey(KeyCode.A))
        {
            x-= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            x += 1;
            
        }

        rb.AddForce(new Vector2(x, 0));
        // rb.velocity = new Vector3(x, 0, 0);
    }
}
