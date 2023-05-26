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

    public List<SkillInTree> allSkills = new List<SkillInTree>();
    public List<SkillInTree> lockedSkills = new List<SkillInTree>();
    public List<SkillInTree> unlockedSkills = new List<SkillInTree>();
    public List<SkillInTree> unlockableSkills = new List<SkillInTree>();
    //Skills currently used by the player
    public List<SkillSlot> currentSkills = new List<SkillSlot>();

    private void Start()
    {
        player = GameObject.FindWithTag("Player");

        UploadTree();
    }

    public void UploadTree()
    {
        //First clear the lists
        allSkills.Clear();
        lockedSkills.Clear();
        unlockedSkills.Clear();
        unlockableSkills.Clear();

        //Add all skills in the tree to allSkills
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i); //Get all skills in tree
            SkillInTree skill = child.gameObject.GetComponent<SkillInTree>(); //Get the Script of eack skill
            allSkills.Add(skill); //Add it to the List
            //Debug.Log("Add skill in Skilltree : " + child);
        }

        //Then add the correct skills to each list
        //Add all unlocked skills in the tree to unlockedSkills
        foreach (SkillInTree skill in allSkills)
        {
            if (skill.isLock)
            {
                lockedSkills.Add(skill);
            }
            else
            {
                unlockedSkills.Add(skill);
            }
            if (skill.isUnlockable)
            {
                unlockableSkills.Add(skill);
            }
        }
    }
}
