using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : ObjectManager
{
    public override void DisplayText() 
    {
        
        IODisplay();
    }

    void IODisplay() 
    {
        Debug.Log("IO");
        text.FakeStart(words);
    }
}