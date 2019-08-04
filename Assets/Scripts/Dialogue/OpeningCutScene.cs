using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningCutScene : MonoBehaviour
{
    public DialogueManager dialogue;
    public string[] lines;
    public static bool doneTalking = false;

    // Start is called before the first frame update
    void Start() 
    {
        dialogue.OpeningandClosing(lines);
    }

    void LateUpdate() 
    {
        if (doneTalking) 
        {
            Debug.Log("We are done talking. In fact.");
            FadeOut.CallFade(false, sceneChange: true);
            doneTalking = false;
        }
    }
}
