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
    bool hasPeaked;
    // Start is called before the first frame update
    void Start()
    {
        c = image.color;
        c.a = 0;
        isFading = false;
        hasPeaked = false;
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
            if (!hasPeaked) {
                c.a += changeVal;
            }
            if (hasPeaked) {
                hasPeaked = true;
                c.a -= changeVal;
            }
            if (c.a <= 0) {
                isFading = false;
            }
        }

        if (c.a >= 1) {
            hasPeaked = true;
        }
    }

    void CallFade() {

    }
}
