using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skills", menuName = "Skills/Dash")]
public class DashSkill : Skill_SO
{
    //Euh le Dash marche pas mais la capa se lance bien dans le player donc is okay on va dire

    public float dashVelocity;

    public override void Activate(GameObject parent)
    {
        PlayerMovement movement = parent.GetComponent<PlayerMovement>();
        Rigidbody rb = parent.GetComponent<Rigidbody>();

        rb.AddForce(movement.movementInput.normalized * dashVelocity);
    }
}
