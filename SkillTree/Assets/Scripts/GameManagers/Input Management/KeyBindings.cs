using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = " KeyBindings", menuName = "KeyBindings")]
public class KeyBindings : ScriptableObject
{
    [System.Serializable]
    public class KeyBindingCheck
    {
        public KeybindingActions keyBindingActions;
        public KeyCode keyCode;
    }

    public KeyBindingCheck[] keyBindingChecks;
}
