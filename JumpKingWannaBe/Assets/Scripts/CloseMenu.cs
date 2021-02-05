using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CloseMenu : MonoBehaviour
{
    public GameObject thisMenu;
    public GameObject thisInfoMenu;
    void Start()
    {
        thisInfoMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonUp("BackM"))
        {
            thisMenu.SetActive(false);
            Time.timeScale = 1;
        }
        if (CrossPlatformInputManager.GetButtonUp("Info"))
        {
            thisInfoMenu.SetActive(true);
        }
        if (CrossPlatformInputManager.GetButtonUp("BackInfo"))
        {
            thisInfoMenu.SetActive(false);
        }
    }
}
