using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;


public class Skill_SO : ScriptableObject
{
    //Don't modify this dynamically, use another Scriptable Object of type : Skill_SO
    //All variables and Methods will be inherited and modifiable in the child
    //You can also add new uniques variables in the child
    //Don't forget to add [CreateAssetMenu(fileName = "Skills", menuName = "Skills/SkillName")] at the top of the child's script

    public string skillName;
    public string description;
    public Renderer rend;

    public float startupTime;
    public float activeTime;
    public float cooldownTime;

    //Those Methods are used in Skills in the SkillTree
    public virtual void LockEffect() { }
    public virtual void UnlockableEffect() { }
    public virtual void UnlockEffect() { }

    //Those Methods are used in Skills in game
    public virtual void Startup(GameObject parent) { }
    public virtual void Activate(GameObject parent) { }
    public virtual void Cooldown(GameObject parent) { }
}
