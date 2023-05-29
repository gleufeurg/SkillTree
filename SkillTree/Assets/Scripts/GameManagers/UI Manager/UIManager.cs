using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Singleton

    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    #endregion

    public GameObject skillTree;

    public void ToggleTree()
    {
        skillTree.SetActive(!skillTree.gameObject.activeSelf);

        if (skillTree.gameObject.activeSelf)
            OpenTree();
        else if (!skillTree.gameObject.activeSelf)
            CloseTree();
    }

    public void CloseTree()
    {
        skillTree.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void OpenTree()
    {
        skillTree.SetActive(true);
        Time.timeScale = 0f;
    }

}
