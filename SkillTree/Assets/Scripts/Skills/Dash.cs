using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skills", menuName = "Skills/Dash")]
public class Dash : Skill_SO
{
    public float dashVelocity;

    public override void Activate(GameObject parent)
    {
        PlayerMovement movement = parent.GetComponent<PlayerMovement>();
        Rigidbody rb = parent.GetComponent<Rigidbody>();

        rb.AddForce(movement.movementInput.normalized * dashVelocity, ForceMode.Impulse);
        Debug.Log("Dash");
    }
}
