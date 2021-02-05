using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MainMenu : MonoBehaviour
{
    public GameObject[] other;
    public GameObject LevelSelect;
    public GameObject thisMenu;

    void Start()
    {
        LevelSelect.SetActive(false);
    }

    void Update()
    {
        if (CrossPlatformInputManager.GetButtonUp("PlayM"))
        {
            LevelSelect.SetActive(true);
            thisMenu.SetActive(false);
        }
    }

    
}
