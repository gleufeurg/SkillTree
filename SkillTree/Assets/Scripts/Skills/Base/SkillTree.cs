using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    #region Singleton

    public static SkillTree Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject.transform.parent);
        }
    }

    #endregion

    GameObject player;
    PlayerSkill playerSkill;

    public List<SkillInTree> allSkills = new List<SkillInTree>();
    public List<SkillInTree> lockedSkills = new List<SkillInTree>();
    public List<SkillInTree> unlockedSkills = new List<SkillInTree>();
    public List<SkillInTree> unlockableSkills = new List<SkillInTree>();

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerSkill = player.GetComponent<PlayerSkill>();

        //Add all skills in the tree to allSkills
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            allSkills.Add(child.gameObject.GetComponent<SkillInTree>());
            //Debug.Log("Add skill in Skilltree : " + child);
        }
        //Add all locked skills in the tree to lockedSkills
        
        //Add all unblockable skills in the tree to unlockableSkills
        ///Maybe better to create a new Method UpdateSkills or UpdateTree
        ///--> Clear all Lists and re add all skills depending of their bool locked and unlockable
        /// A skill can be locked and unlockable || locked and not unlockable || unlocked and not unlockable :
        ///--> No need to verify with && behaviours as a skill is automatically not unlockable if it is unlocked
    }

    public void UploadTree()
    {
        //First clear the lists
        unlockedSkills.Clear();
        playerSkill.skills.Clear();

        //Then add the correct skills to each list
        //Add all unlocked skills in the tree to unlockedSkills
        foreach (SkillInTree skill in allSkills)
        {
            if (!skill.isLock)
            {
                unlockedSkills.Add(skill);
                playerSkill.skills.Add(skill.skill);
            }
        }
    }
}
