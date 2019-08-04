using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningCutScene : MonoBehaviour
{
    public DialogueManager dialogue;
    public string[] lines;
    private bool doneTalking;
    // Start is called before the first frame update
    void Start() 
    {
        Debug.Log("start");
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        dialogue.OpeningandClosing(lines);
    }

    void LateUpdate() 
    {
        if (doneTalking) 
        {
            FadeOut.CallFade(sceneChange: true);
        }
    }
}
