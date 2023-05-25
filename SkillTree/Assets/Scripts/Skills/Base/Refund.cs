using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Refund : MonoBehaviour
{
    [SerializeField] private bool refundMode;
    public List<SkillInTree> refundSkills = new List<SkillInTree>();

    public void RefundMode()
    {
        refundMode = !refundMode;

        if (refundMode)
        {
            //In waiting of a correct Add listener implementation, I add all skills in refundSkills
            foreach (var item in SkillTree.Instance.allSkills)
            {
                refundSkills.Add(item);
            }
            transform.Find("RefundButton").transform.Find("Cancel").transform.gameObject.SetActive(true);
            transform.Find("RefundButton").transform.Find("ApplyRefund").transform.gameObject.SetActive(true);
            //Debug.Log("add Refund");
        }
        else
        {
            CancelRefund();
        }
    }

    public void CancelRefund()
    {
        refundMode = false;
        refundSkills.Clear();
        transform.Find("RefundButton").transform.Find("Cancel").transform.gameObject.SetActive(false);
        transform.Find("RefundButton").transform.Find("ApplyRefund").transform.gameObject.SetActive(false);
    }

    public void ApplyRefund()
    {
        foreach (var skill in refundSkills)
        {
            skill.Refund();
        }
        refundMode = false;
        //refundSkills.Clear();
        transform.Find("RefundButton").transform.Find("Cancel").transform.gameObject.SetActive(false);
        transform.Find("RefundButton").transform.Find("ApplyRefund").transform.gameObject.SetActive(false);
    }
}
