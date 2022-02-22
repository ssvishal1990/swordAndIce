using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Guard : MonoBehaviour
{
    bool guardEnabled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enableGuard(InputAction.CallbackContext context){
        if(context.canceled || context.started) return;
        guardEnabled = !guardEnabled;
        Debug.Log("Guard status --> " + guardEnabled);
    }

    internal bool isGuardActive()
    {
        return guardEnabled;
    }
}
