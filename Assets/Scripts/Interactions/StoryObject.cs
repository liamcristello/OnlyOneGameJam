using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryObject : MonoBehaviour
{
    public static void NextScene() 
    {
        FadeOut.CallFade(sceneChange: true);
    }
}
