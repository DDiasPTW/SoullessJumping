using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public GameObject thisMenu;
    public Button[] PlayButtons;
    public int levelUnlocked;
    private bool canClick;
    private int startLevel = 1;

    public Button[] ButtonsSide;

    private void Start()
    {
        //PlayerPrefs.SetInt("LevelUnlocked", 2);
        //Sons e Afins
        PlayerPrefs.GetInt("Musica", 1);

        //Niveis
        if (PlayerPrefs.GetInt("LevelUnlocked") < startLevel)
        {
            PlayerPrefs.SetInt("LevelUnlocked", 1);
        }
   
        //PlayerPrefs.DeleteAll();
        levelUnlocked = PlayerPrefs.GetInt("LevelUnlocked");
        for (int i = 0; i < PlayButtons.Length; i++)
        {
            if (i + 1 > PlayerPrefs.GetInt("LevelUnlocked"))
            {
                PlayButtons[i].interactable = false;             
            }            
        }
    }


    private void Update() // Tem que se ir dando update ha medida que se vai metendo mais niveis
    {
        PlayerPrefs.GetInt("LevelUnlocked");
        //BOTAO PARA TESTAR NIVEIS (APAGAR QUANDO FOR PARA LANÇAR)
        //if (CrossPlatformInputManager.GetButtonUp("Teste"))
        //{
        //    PlayerPrefs.SetInt("LevelUnlocked", 20);
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //}
        //
        for (int i = 0; i < PlayButtons.Length; i++)
        {
            if (CrossPlatformInputManager.GetButtonUp("Lvl" + (i+1)) && PlayButtons[i].interactable == true)
            {
                //Debug.Log(i);
                SceneManager.LoadScene(i+1);
                Time.timeScale = 1;
            }
        }
        //
        levelUnlocked = PlayerPrefs.GetInt("LevelUnlocked");

        


    }
}
