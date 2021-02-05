using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;   

public class CoinManager : MonoBehaviour
{
    private int currentLvl;
    float currentTime = 0f;
    public bool acabou = false;
    private GameObject lvlNext;
    float startingTime;
    public Text TimerText;

    //PosNivel
    float finalTime;
    public Text FinalTime;
    public Text NextCoinText;
    public Text PBTimeText;
    public float goldTime;
    public float silverTime;
    public GameObject[] Moedas;

    void Start()
    {
        finalTime = 0;
        currentTime = startingTime;
        currentLvl = SceneManager.GetActiveScene().buildIndex;
        lvlNext = GameObject.FindGameObjectWithTag("Next");
        acabou = lvlNext.GetComponent<NextLevel>().ended;
        
        PlayerPrefs.GetFloat("PB" + currentLvl, 0);
    }

    // Update is called once per frame
    void Update()
    {
        acabou = lvlNext.GetComponent<NextLevel>().ended;
        if (!acabou)
        {
            Timer();
        }
        else
        {
            CheckCoin();
        } 
    }


    void CheckCoin()
    {    
        finalTime = currentTime;
        FinalTime.text = finalTime.ToString("F2");
        CheckTime();
        //Definir Moeda
        if (currentTime <= goldTime)
        {
            PlayerPrefs.SetString("Coin" + currentLvl, "Gold");
            Debug.Log("Gold");
        }
        else if (currentTime <= silverTime && PlayerPrefs.GetString("Coin" + currentLvl) != "Gold")
        {
            PlayerPrefs.SetString("Coin" + currentLvl, "Silver");
            Debug.Log("Silver");
        }
        else
        {
            if (PlayerPrefs.GetString("Coin" + currentLvl) != "Gold" && (PlayerPrefs.GetString("Coin" + currentLvl) != "Silver"))
            {
                PlayerPrefs.SetString("Coin" + currentLvl, "Bronze");
                Debug.Log("Bronze");
            }

        }
        //Menu NextLevel
        if (finalTime <= PlayerPrefs.GetFloat("PB" + currentLvl) && PlayerPrefs.GetFloat("PB" + currentLvl) != 0)
        {
            PlayerPrefs.SetFloat("PB" + currentLvl, finalTime);
            PBTimeText.text = PlayerPrefs.GetFloat("PB" + currentLvl).ToString("F2");
        }else if (PlayerPrefs.GetFloat("PB" + currentLvl) == 0)
        {
            PlayerPrefs.SetFloat("PB" + currentLvl, finalTime);
            PBTimeText.text = PlayerPrefs.GetFloat("PB" + currentLvl).ToString("F2");
        }
        else
        {
            PlayerPrefs.GetFloat("PB" + currentLvl);
            PBTimeText.text = PlayerPrefs.GetFloat("PB" + currentLvl).ToString("F2");
        }

        

    }

    void CheckTime()
    {
        if (finalTime <= goldTime)
        {
            Moedas[0].SetActive(true);
            Moedas[1].SetActive(false);
            Moedas[2].SetActive(false);
            NextCoinText.text = "--;--";
        } else if (finalTime <= silverTime /*&& PlayerPrefs.GetString("Coin" + currentLvl) != "Gold"*/)
        {
            Moedas[0].SetActive(false);
            Moedas[1].SetActive(true);
            Moedas[2].SetActive(false);
            NextCoinText.text = goldTime.ToString() + " secs";
        }
        else /*if (PlayerPrefs.GetString("Coin" + currentLvl) != "Gold" && (PlayerPrefs.GetString("Coin" + currentLvl) != "Silver"))*/
        {
            Moedas[0].SetActive(false);
            Moedas[1].SetActive(false);
            Moedas[2].SetActive(true);
            NextCoinText.text = silverTime.ToString() + " secs";
        }
    }

    void Timer()
    {
        currentTime += Time.deltaTime;
        TimerText.text = currentTime.ToString("F1");
    }
}
