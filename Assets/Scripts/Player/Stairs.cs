using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stairs : MonoBehaviour
{

    public GameObject up;
    public GameObject down;

    public bool move;

    void OnTriggerEnter2D(Collider2D other)
    {
        // If the Collider2D belongs to the player
        if (other.gameObject.CompareTag("Player"))
        {
            up.SetActive(true);
            down.SetActive(true);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // If the Collider2D belongs to the player
        if (other.gameObject.CompareTag("Player"))
        {
            UseStairs();
        }
    }

    // Called when something exits this object's box-collider trigger.
    void OnTriggerExit2D(Collider2D other)
    {
        // If the Collider2D belongs to the player
        if (other.gameObject.CompareTag("Player"))
        {
            up.SetActive(false);
            down.SetActive(false);
        }
    }

    void UseStairs()
    {
        Debug.Log("onstairs");
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("hello up");
            move = true;
            StartCoroutine(please());
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("hello down");
            move = false;
            StartCoroutine(please());
        }
    }

    IEnumerator please()
    {
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        FadeOut.CallFade(move);
        yield return new WaitForSeconds(0.2f);
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
