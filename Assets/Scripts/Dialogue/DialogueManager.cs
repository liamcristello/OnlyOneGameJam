using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public Image panel; 
    private Queue<string> sentences;

    private bool firstScene = false;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        dialogueText.text = "";
        panel.enabled = false;
    }

    public void StartDialogue(Dialogue dialogue) {
        
        GameObject.Find("Player").GetComponent<Movement>().enabled = false;
        panel.enabled = true;
        sentences.Clear();
        

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}
    }

    public void OpeningandClosing(string[] words) 
    {
        firstScene = true;
        sentences = new Queue<string>();
        var d = new Dialogue();
        d.sentences = words;

        StartDialogue(d);
        DisplayNextSentence();
    }

   public void DisplayNextSentence ()
	{
        // if there are no more sentences in the queue
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        //the next sentence to be displayed (removed from queue)
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
	}

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            DisplayNextSentence();
        }
    }

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return new WaitForSeconds(.02f);
		}
	}

    IEnumerator Wait () 
    {
        yield return new WaitForSeconds(.5f);
        InteractableObject.inZone = true;
    }

	void EndDialogue()
	{
        if (firstScene) {
            OpeningCutScene.doneTalking = true;
            firstScene = false;
        }

        
        dialogueText.text = "";
        GameObject.Find("Player").GetComponent<Movement>().enabled = true;
        panel.enabled = false;
        StartCoroutine(Wait());
	}

}
