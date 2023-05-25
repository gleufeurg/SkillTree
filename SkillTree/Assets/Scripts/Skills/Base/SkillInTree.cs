using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using UnityEditor.Animations;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class SkillInTree : MonoBehaviour
{
    //The skill imperatively need to have a reference in order to the script (and the game) to work
    //The skill correspond to the ability or passive you gain by bying this skill in the tree
    [Tooltip("The ability or passive you gain by buying this skill in the tree")]
    [SerializeField] public Skill_SO skill;

    [Header("Data received")]
    [Tooltip("Sprite from the Scriptable Object \"skill\"")]
    [SerializeField] Sprite sprite;

    [Space(20f)]

    public bool isLock = true;
    public bool isUnlockable = false;
    public GameObject[] unlockables;

    public Button button;

    public enum SkillState
    {
        locked,
        unlockable,
        unlocked,
    }
    SkillState state = SkillState.locked;

    private void Awake()
    {
        #region Set all the Data received from the Scriptable Object

        sprite = skill.sprite;

        gameObject.GetComponent<Image>().sprite = sprite;

        #endregion

        button = gameObject.GetComponent<Button>();
    }

    void Start()
    {
        if (!isUnlockable && isLock)
            button.interactable = false;

        //button.onClick.AddListener(DoWap);
    }

    void Update()
    {
        #region Switch state

        //Switch the state of the skill and activate its effect(s) (if it has)
        //Automatically switch state depending on isLock and isUnlockable
        //Doesn't trigger the previous state effect if a state change is made
        //Doesn't change the bool values by itself, the Functions / Methods does
        //A Skill can be (the values of the bool isLock and isUnlockable) :
        //locked and not unlockable
        //locked and unlockable
        //unlocked
        //A Skill can not be :
        //unlocked and unlockable
        //So the Methods has to change the values
        //Be sure to change the state at the very end of the functions so there is no problem
        ///The Effects (LockEffect, UnlockableEffect and UnlockedEffect)
        ///takes place in the Tree, they have no effect outside of it (except for the stats changes and some exceptions)
        ///They are not the Skill used by the player against monsters (but obviously they help him to beat them)
        switch (state)
        {
            case SkillState.locked:
                if (isUnlockable)
                {
                    state = SkillState.unlockable;
                    break;
                }
                skill.LockEffect();
                break;
            case SkillState.unlockable:
                if (!isLock)
                {
                    state = SkillState.unlocked;
                    break;
                }
                else if (isLock)
                {
                    state = SkillState.locked;
                    break;
                }
                skill.UnlockableEffect();
                break;
            case SkillState.unlocked:
                if (isLock)
                {
                    state = SkillState.locked;
                    break;
                }
                else if (isUnlockable)
                {
                    state = SkillState.unlockable;
                    break;
                }
                skill.UnlockEffect();
                break;
        }

        #endregion
    }

    #region SetStates


    //The Methods don't change the skill state by themself (the switch does)
    //They only change the values of the bool isLock and isUnlockable (and some other effects)
    //They do not trigger the Effect of the skill (the switch in the update does)

    public void Unlockable()
    {
        //Can't be Unlockable if it is already unlocked or unlockable
        if (isUnlockable || !isLock)
            return;

        isUnlockable = true;
        button.interactable = true;
    }

    public void Unlock()
    {
        //Can't be Unlocked if it is not unlockable
        //Unlocked make the skill Unblockable, so isUnlockable is false
        //Set all the skills in unlockables, unlockable (pretty clear)
        if (!isUnlockable)
            return;

        isLock = false;
        isUnlockable = false;
        button.interactable = false;

        foreach (var item in unlockables)
        {
            SkillInTree _skill = item.GetComponent<SkillInTree>();
            _skill.Unlockable();
        }

        SkillTree.Instance.UploadTree();

        //Debug
        //Debug.Log("Unlocked" + skill.skillName);
    }

    public void Lock()
    {
        //Return to a previous state in case the player want a refund of skillpoints
        //Set all the skills in unlockables now locked (if they are not unlocked)
        //Except if they are unlocked and have another connection branch (like in Path of Exile)

        /*if (!isLock)
        {
            foreach (var item in unlockables)
            {
                SkillInTree _skill = item.GetComponent<SkillInTree>();
                if(!_skill.isLock || !_skill.isUnlockable)
                {
                    return;
                }
                else if(_skill.isUnlockable)
                {
                    isUnlockable = true;
                    isLock = true;
                    _skill.Lock();
                }
            }
        }
        else if(isLock)
        {
            isUnlockable = false;
        }*/
        Debug.Log("Lock : " + skill.skillName);
    }

    public void Refund()
    {
        skill.RefundEffect();
        Lock();
    }

    #endregion

    //Debug
    public void DoWap()
    {
        Debug.Log("DoWap");
    }
}
