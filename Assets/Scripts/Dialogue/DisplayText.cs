using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour
{
    // Reference to a TMPro object to display text in
    public TextMeshProUGUI display;

    // int to represent the current dialogue character
    public int index;

    // string array to represent dialogue
    private string[] words;

    // float to represent the delay before each new character of dialogue is shown
    public float waitSpeed;

    // Reference to game object acting as our button to press to continue
    public Button proceed;

    // bool to determine whether to show text and related UI
    public bool show = false;
    public bool isSO = false; //checks to see if it is a story object


    //Fake start method
    public void FakeStart(string[] w, bool isSo = false) 
    {
        isSO = isSo;
        words = w;
        // Stops the player from moving during dialogue
        GameObject.Find("Player").GetComponent<Movement>().enabled = false;

        // Disables the continue button by default
       // proceed.SetActive(false);

        // Sets the display object's text to nothing by default
        display.text = "";

        //start
        StartCoroutine(Type());
    }

    // Update is called once per frame
    void Update()
    {   
        if (words != null) {
            // When E is pressed, text/UI should display
            if (Input.GetKeyDown(KeyCode.E)) {
                Display();
            }

            // If text and UI are being shown
            if (show) {
                // If all current text is displayed, display the continue button
                if (display.text == words[index]) {
                   // proceed.SetActive(true);

                    // When continue button is pressed here, begin to display next batch of text
                    if (Input.GetKeyDown(KeyCode.E)) { 
                        Next();
                    }
                }
            }
        }
    }

    // IEnumerator to add text from array to display object, character-by-character
    IEnumerator Type() {
        // Incremement through each character in the current text to display
        foreach (char character in words[index]) {
            // Display the current character
            display.text += character;
            // Wait the defined delay time before displaying the next character
            yield return new WaitForSeconds(waitSpeed);
        }
    }

    // Transitions to next batch of text
    public void Next() {
        // Deactivates continue button
       // proceed.SetActive(false);

        // Clears text and proceeds to next line of dialogue, if this is not the final line
        if (index < words.Length - 1) {
            index += 1;
            display.text = "";
            StartCoroutine(Type());
        }

        // If this is the last line of dialogue
        else {
            // Clear the text
            display.text = "";

            // Let the player move again
            GameObject.Find("Player").GetComponent<Movement>().enabled = true;

            // Turn off text/UI
            show = false;
            
            ObjectManager.inZone = true;
            if (isSO)
                StoryObject.NextScene(); //switches to next scene after dialogue has been said
        }
    }

    // When text should be displayed, start the coroutine and turn on UI
    public void Display(bool hit = false) 
    {
        show = true;
    }
}
