using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Image image;
    public float changeVal;
    
    private static bool isFading = false;
    private static bool change = false;
    private bool hasPeaked = false;
    private Color c;

    // Start is called before the first frame update
    void Start()
    {
        c = image.color;
        c.a = 0;
    }

    public static void CallFade(bool moveUp = false, bool sceneChange = false) //to call the fade in other scrips
    {
        //to start the fade
        isFading = true; 

        if (sceneChange) 
        {
           change = sceneChange;        
        }
        
        //move the player up or down a level
        if(moveUp) Debug.Log("Switch floors!");
        Movement.ChangeFloors(moveUp);
    }

    void LoadNextScene() 
    {
        StartCoroutine(WaitFor());
    }
    IEnumerator WaitFor() {
      
        yield return null;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    // Update is called once per frame
    void Update()
    {
        image.color = c; //sets the color each frame

        if (isFading) {
           
            if (!hasPeaked) {
                c.a += changeVal;
            }
            if (hasPeaked) {
                hasPeaked = true;
                c.a -= changeVal;
            }
            if (c.a <= 0) {
                isFading = false;
                hasPeaked = false;
            }
        }

        if (c.a >= 1) {
            hasPeaked = true;
        }

        if (change)
            LoadNextScene();
    }
}
