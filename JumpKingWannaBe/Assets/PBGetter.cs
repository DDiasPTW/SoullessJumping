using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PBGetter : MonoBehaviour
{
    public int thisLevel;
    public Text PBText;
    void Start()
    {
        
    }

    
    void Update()
    {
        PlayerPrefs.GetFloat("PB" + thisLevel);
        PBText.text = PlayerPrefs.GetFloat("PB" + thisLevel).ToString("F2") + " s ";
    }
}
