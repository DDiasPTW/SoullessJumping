using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ResumeButton : MonoBehaviour
{
    public GameObject PauseMenu;
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Resume"))
        {
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
        }
    }
}
