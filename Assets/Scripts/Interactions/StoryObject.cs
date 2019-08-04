using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryObject : ObjectManager
{
    public override void DisplayText() 
    {
        SODisplay();
    }

    void SODisplay() 
    {
        text.FakeStart(words, true);
    }
    public static void NextScene() 
    {
        FadeOut.CallFade(sceneChange: true);
    }
}
