using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{

    public GameObject map;
    // Start is called before the first frame update
    void Start()
    {
        map.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) {
            //Debug.Log("Yeet");
            map.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.M)) {
            //Debug.Log("Yote");
            map.SetActive(false);
        }
    }
}
