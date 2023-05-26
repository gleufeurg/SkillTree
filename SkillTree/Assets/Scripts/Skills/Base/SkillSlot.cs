using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSlot : MonoBehaviour
{
    //The skill / skills are of type : Skill_SO but don't be fooled they are childs of type Skill_SO, not the script Skill_SO itself
    //So never add the original Skill_SO in a GameObject

    private InputManager inputManager;

    public Skill_SO skill;

    float startupTime;
    float activeTime;
    float cooldownTime;

    //Debug
    Renderer rend;

    enum SkillState
    {
        ready,
        startup,
        active,
        cooldown,
    }
    SkillState state = SkillState.ready;

    private void Start()
    {
        inputManager = InputManager.Instance;

        //Debug
        rend = GetComponent<Renderer>();
    }

    private void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        if (skill == null)
            return;

        switch (state)
        {
            case SkillState.ready:
                if (inputManager.GetKeyDown(skill.key))
                {
                    skill.Startup(gameObject);
                    startupTime = skill.startupTime;
                    state = SkillState.startup;

                    //Debug
                    //Debug.Log("Start");
                    rend.material.color = Color.yellow;
                }
                break;
            case SkillState.startup:
                if (startupTime > 0)
                {
                    startupTime -= Time.deltaTime;
                }
                else if (startupTime <= 0)
                {
                    skill.Activate(gameObject);
                    activeTime = skill.activeTime;
                    state = SkillState.active;

                    //Debug
                    //Debug.Log("Activate");
                    rend.material.color = Color.red;
                }
                break;
            case SkillState.active:
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else if (activeTime <= 0)
                {
                    skill.Cooldown(gameObject);
                    cooldownTime = skill.cooldownTime;
                    state = SkillState.cooldown;

                    //Debug
                    //Debug.Log("Cooldown");
                    rend.material.color = Color.blue;
                }
                break;
            case SkillState.cooldown:
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else if (cooldownTime <= 0)
                {
                    state = SkillState.ready;

                    //Debug
                    //Debug.Log("Ready");
                    rend.material.color = Color.white;
                }
                break;
        }
    }
}
