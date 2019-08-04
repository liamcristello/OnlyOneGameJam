using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryObject : ObjectManager
{
    public static void NextScene() 
    {
        FadeOut.CallFade(sceneChange: true);
    }
}
