using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MuteSounds : MonoBehaviour
{
    private AudioSource aS;
    void Start()
    {
        //aS = GetComponent<AudioSource>();
        PlayerPrefs.GetInt("Sons", 1);
    }


    void Update()
    {
        if (CrossPlatformInputManager.GetButtonUp("Sons"))
        {
            //DESLIGA SONS + PLAYERPREFS SONS = 0... ELSE = 1
            if (PlayerPrefs.GetInt("Sons") == 1)
            {
                PlayerPrefs.SetInt("Sons", 0);
            }
            else
            {
                PlayerPrefs.SetInt("Sons", 1);
            }
        }


        //if (PlayerPrefs.GetInt("Sons") == 0)
        //{
        //    aS.volume = 0;
        //}
        //else
        //{
        //    aS.volume = 0.8f;
        //}
    }
}
