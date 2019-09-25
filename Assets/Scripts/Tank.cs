using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public RectTransform gun;

    [Range(1, 50)]
    public float movementSpeed;
    [Range(1, 50)]
    public float rotationSpeed;

    [HideInInspector]
    public bool isAcceptingInput = false;
    [HideInInspector]
    public float timeRemaining;

    private Vector3 input;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isAcceptingInput)
            HandleInput();
    }

    void HandleInput()
    {
        float x = 0;
        float rot = 0;

        if (Input.GetKey(KeyCode.A))
            x -= 1;
        if (Input.GetKey(KeyCode.D))
            x += 1;
        if (Input.GetKey(KeyCode.Q))
            rot -= 1;
        if (Input.GetKey(KeyCode.E))
            rot += 1;
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(Shoot());

        rb.velocity = new Vector3(x * movementSpeed, rb.velocity.y, 0);
        gun.localEulerAngles += new Vector3(0, 0, - rot * rotationSpeed);
        LockGunRotation();
    }

    IEnumerator Shoot()
    {


        yield return null;
    }

    void LockGunRotation()
    {
        if (gun.localEulerAngles.z >= 100 && gun.localEulerAngles.z < 180)
            gun.localEulerAngles = new Vector3(0, 0, 100);
        else if (gun.localEulerAngles.z <= 260 && gun.localEulerAngles.z > 180)
            gun.localEulerAngles = new Vector3(0, 0, 260);
    }
}
