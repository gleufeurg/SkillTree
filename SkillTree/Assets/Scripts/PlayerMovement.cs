using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float baseSpeed;
    [HideInInspector] public float speed;
    [HideInInspector] public Vector2 movementInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = baseSpeed;
    }

    private void FixedUpdate()
    {
        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = speed * Time.deltaTime * movementInput;
    }
}
