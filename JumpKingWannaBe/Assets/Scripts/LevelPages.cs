using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class LevelPages : MonoBehaviour
{
    public GameObject NextPage;
    public GameObject ThisPage;
    public GameObject PreviousPage;

    void Update()
    {
        if (CrossPlatformInputManager.GetButtonUp("NxtLevel"))
        {
            ThisPage.SetActive(false);
            NextPage.SetActive(true);
        }

        if (CrossPlatformInputManager.GetButtonUp("PreviousLevel"))
        {
            ThisPage.SetActive(false);
            PreviousPage.SetActive(true);
        }
    }
}
