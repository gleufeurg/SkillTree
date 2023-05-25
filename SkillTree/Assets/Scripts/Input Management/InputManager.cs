using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Singleton

    public static InputManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null && Instance != this)
        {
            Debug.LogError("Multiple instances of Input Manager");
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    #endregion

    [SerializeField] private KeyBindings keyBindings;

    //Check the key binding
    public KeyCode GetKeyForAction(KeybindingActions keyBindingActions)
    {
        //Find KeyCode
        //Take all the keys from the ScriptableObject attached to this gameObject
        //Compare them to the keyBindingActions wanted from the parameter
        //If right : do the code else : return none (no KeyCode correspond)

        foreach (KeyBindings.KeyBindingCheck keyCheck in keyBindings.keyBindingChecks)
        {
            if (keyCheck.keyBindingActions == keyBindingActions)
            {
                return keyCheck.keyCode;
            }
        }
        return KeyCode.None;
    }

    //Get the right input from the right KeyCode
    public bool GetKeyDown(KeybindingActions key)
    {
        //Check for Key
        //Take all the keys from the ScriptableObject attached to this gameObject
        //Compare them to the key wanted from the parameter
        //If right : do the code else : return false
        foreach (KeyBindings.KeyBindingCheck keyCheck in keyBindings.keyBindingChecks)
        {
            if (keyCheck.keyBindingActions == key)
            {
                return Input.GetKeyDown(keyCheck.keyCode);
            }
        }
        return false;
    }
    
    public bool GetKey(KeybindingActions key)
    {
        //Check for Key
        //Take all the keys from the ScriptableObject attached to this gameObject
        //Compare them to the key wanted from the parameter
        //If right : do the code else : return false
        foreach (KeyBindings.KeyBindingCheck keyCheck in keyBindings.keyBindingChecks)
        {
            if (keyCheck.keyBindingActions == key)
            {
                return Input.GetKey(keyCheck.keyCode);
            }
        }
        return false;
    }
    
    public bool GetKeyUp(KeybindingActions key)
    {
        //Check for Key
        //Take all the keys from the ScriptableObject attached to this gameObject
        //Compare them to the key wanted from the parameter
        //If right : do the code else : return false
        foreach (KeyBindings.KeyBindingCheck keyCheck in keyBindings.keyBindingChecks)
        {
            if (keyCheck.keyBindingActions == key)
            {
                return Input.GetKeyUp(keyCheck.keyCode);
            }
        }
        return false;
    }
}
