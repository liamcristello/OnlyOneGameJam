using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Image image;
    bool isFading;
    Color c;
    public float changeVal;
    // Start is called before the first frame update
    void Start()
    {
        c = image.color;
        c.a = 0;
        isFading = false;
    }

    // Update is called once per frame
    void Update()
    {
        image.color = c;
        if (!isFading && Input.GetKeyDown(KeyCode.Space)) {
            isFading = true;
            Debug.Log("Start fading!");
        }

        if (isFading) {
            Debug.Log("Alpha value is " + c.a);
            c.a += changeVal;
        }

        if (c.a == 1) {
            isFading = false;
        }
    }

    void CallFade() {
        
    }
}
