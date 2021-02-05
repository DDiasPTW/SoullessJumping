using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectlvls : MonoBehaviour
{
    public GameObject thisLvlMenu;
    
    
    // Start is called before the first frame update
    void Start()
    {
        thisLvlMenu.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            thisLvlMenu.SetActive(true);
        }
    }
}
