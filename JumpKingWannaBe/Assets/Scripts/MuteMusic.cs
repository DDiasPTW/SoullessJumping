using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MuteMusic : MonoBehaviour
{
    private AudioSource aS;

    static MuteMusic instance;
    void Start()
    {
        aS = GetComponent<AudioSource>();
        PlayerPrefs.GetInt("Musica", 1);
        if (PlayerPrefs.GetInt("Musica") == 0)
        {
            aS.volume = 0;
        }
        else
        {
            aS.volume = 1f;
        }
    }

   
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonUp("Musica"))
        {
            //DESLIGA SONS + PLAYERPREFS SONS = 0... ELSE = 1
            if (PlayerPrefs.GetInt("Musica") == 1)
            {
                PlayerPrefs.SetInt("Musica", 0);
            }
            else
            {
                PlayerPrefs.SetInt("Musica", 1);
            }
        }


        if (PlayerPrefs.GetInt("Musica") == 0)
        {
            aS.volume = 0;
        } else
        {
            aS.volume = 1f;
        }

    }
}
