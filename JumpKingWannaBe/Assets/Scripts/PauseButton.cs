using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject NormalUI;
    public GameObject MenuNextLevelMenu;
    private void Start()
    {
        PauseMenu.SetActive(false);
        MenuNextLevelMenu.SetActive(false);
    }
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonUp("Pause"))
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
            NormalUI.SetActive(false);
        }
        if (CrossPlatformInputManager.GetButtonUp("Resume"))
        {
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
            NormalUI.SetActive(true);
        }
        if (CrossPlatformInputManager.GetButtonUp("Back"))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);

        }
        if (CrossPlatformInputManager.GetButtonUp("Quit"))
        {
            Application.Quit();
            Debug.Log("Quit");
        }
        if (CrossPlatformInputManager.GetButtonUp("Restart"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }



    }
}
