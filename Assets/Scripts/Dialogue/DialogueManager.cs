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
    private bool show;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        dialogueText.text = "";
    }

    public void StartDialogue(Dialogue dialogue) {
        
        panel.enabled = true;
        sentences.Clear();
        show = true;

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}
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
			yield return null; //waits a single frame
		}
	}

	void EndDialogue()
	{
        dialogueText.text = "";
        panel.enabled = false;
        InteractableObject.inZone = true;
        GameObject.Find("Player").GetComponent<Movement>().enabled = true;
	}

}
