using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class NextLevel : MonoBehaviour
{
    public GameObject MenuNextLevelMenu;
    public GameObject puzzlePiece;
    public bool ended = false;
    
    void Start()
    {
        puzzlePiece.SetActive(true);
        ended = false;
    }

    void Update()
    {
        if (CrossPlatformInputManager.GetButtonUp("Next"))
        {
            
            MenuNextLevelMenu.SetActive(false);
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ended = true;
            MenuNextLevelMenu.SetActive(true);
            puzzlePiece.SetActive(false);
            Time.timeScale = 1;
            if (PlayerPrefs.GetInt("LevelUnlocked") < SceneManager.GetActiveScene().buildIndex + 1)
            {
                PlayerPrefs.SetInt("LevelUnlocked", SceneManager.GetActiveScene().buildIndex + 1);
            }
            
        }
    }


}
