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
        Debug.Log("start");

        dialogue.OpeningandClosing(lines);

        //doneTalking = true;
    }

    void LateUpdate() 
    {
        if (doneTalking) 
        {
            FadeOut.CallFade(sceneChange: true);
            doneTalking = false;
        }
    }
}
