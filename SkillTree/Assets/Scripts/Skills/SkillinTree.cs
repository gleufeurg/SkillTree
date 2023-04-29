using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillinTree : MonoBehaviour
{
    //The skill imperatively need to have a reference in order to the script (and the game) to work

    [SerializeField] private Skill_SO skill;

    public bool isLock = true;
    public bool isUnlockable = false;
    public GameObject[] unlockables;

    enum SkillState
    {
        locked,
        unlockable,
        unlock,
    }
    SkillState state = SkillState.locked;

    void Start()
    {
        if (!isUnlockable)
            gameObject.SetActive(false);
    }

    void Update()
    {
        switch (state)
        {
            case SkillState.locked:
                if (isUnlockable)
                {
                    state = SkillState.unlockable;
                }
                else if (!isLock)
                {
                    state = SkillState.unlock;
                }
                skill.LockEffect();
                break;
            case SkillState.unlockable:
                if (isLock)
                {
                    state = SkillState.locked;
                }
                skill.UnlockableEffect();
                break;
            case SkillState.unlock:
                if (isLock)
                    state = SkillState.locked;
                else if (isUnlockable)
                    state = SkillState.unlockable;
                skill.UnlockEffect();
                break;
        }
    }

    public void Unlockable()
    {
        isUnlockable = true;
        gameObject.SetActive(true);
        skill.UnlockableEffect();
        state = SkillState.unlockable;
    }

    public void Unlock()
    {
        if (!isUnlockable)
            return;

        isLock = false;
        skill.UnlockEffect();

        foreach (var item in unlockables)
        {
            SkillinTree _skill = item.GetComponent<SkillinTree>();
            _skill.Unlockable();
        }
    }
}
