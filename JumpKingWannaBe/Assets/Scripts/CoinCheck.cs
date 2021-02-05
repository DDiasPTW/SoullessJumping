using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCheck : MonoBehaviour
{
    public int thisLevel;
    public GameObject[] Coins;

    private void Start()
    {
        if (PlayerPrefs.GetString("Coin" + thisLevel) == "Gold")
        {
            Coins[0].SetActive(true);
            Coins[1].SetActive(false);
            Coins[2].SetActive(false);
        }
        else if (PlayerPrefs.GetString("Coin" + thisLevel) == "Silver")
        {
            Coins[0].SetActive(false);
            Coins[1].SetActive(true);
            Coins[2].SetActive(false);
        }
        else if (PlayerPrefs.GetString("Coin" + thisLevel) == "Bronze")
        {
            Coins[0].SetActive(false);
            Coins[1].SetActive(false);
            Coins[2].SetActive(true);
        }
        else
        {
            Coins[0].SetActive(false);
            Coins[1].SetActive(false);
            Coins[2].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetString("Coin" + thisLevel) == "Gold")
        {
            Coins[0].SetActive(true);
            Coins[1].SetActive(false);
            Coins[2].SetActive(false);
        } else if (PlayerPrefs.GetString("Coin" + thisLevel) == "Silver")
        {
            Coins[0].SetActive(false);
            Coins[1].SetActive(true);
            Coins[2].SetActive(false);
        } else if (PlayerPrefs.GetString("Coin" + thisLevel) == "Bronze")
        {
            Coins[0].SetActive(false);
            Coins[1].SetActive(false);
            Coins[2].SetActive(true);
        }
        else
        {
            Coins[0].SetActive(false);
            Coins[1].SetActive(false);
            Coins[2].SetActive(false);
        }
    }
}
