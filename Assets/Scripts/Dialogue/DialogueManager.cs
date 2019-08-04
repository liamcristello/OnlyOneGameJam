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
        var d = new Dialogue();
        d.sentences = words;

        StartDialogue(d);
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
