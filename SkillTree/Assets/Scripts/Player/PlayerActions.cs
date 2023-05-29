using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    InputManager inputManager;
    UIManager uiManager;

    public bool canAct = true;

    private void Start()
    {
        inputManager = InputManager.Instance;
        uiManager = UIManager.Instance;
    }

    private void Update()
    {
        if (!canAct)
            return;

        if (inputManager.GetKeyDown(KeybindingActions.Skilltree))
        {
            uiManager.ToggleTree();
        }
    }
}
