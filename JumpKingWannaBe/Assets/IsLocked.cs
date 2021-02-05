using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsLocked : MonoBehaviour
{
    public GameObject thisLevelBlock;
    public int thisLevelNumber;
    public Color normalColor, lockedColor;

    private void Start()
    {
        if (thisLevelNumber <= PlayerPrefs.GetInt("LevelUnlocked"))
        {
            thisLevelBlock.GetComponent<SpriteRenderer>().color = normalColor;
        }
        else
        {
            thisLevelBlock.GetComponent<SpriteRenderer>().color = lockedColor;
        }
    }

    private void Update()
    {
        if (thisLevelNumber <= PlayerPrefs.GetInt("LevelUnlocked"))
        {
            thisLevelBlock.GetComponent<SpriteRenderer>().color = normalColor;
        }
        else
        {
            thisLevelBlock.GetComponent<SpriteRenderer>().color = lockedColor;
        }
    }

}
