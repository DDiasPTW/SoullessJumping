using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStuff : MonoBehaviour
{
    public GameObject tutMsg;

    private void Start()
    {
        tutMsg.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            tutMsg.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            tutMsg.SetActive(false);
        }
    }
}
