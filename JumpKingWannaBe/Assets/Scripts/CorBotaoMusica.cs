using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorBotaoMusica : MonoBehaviour
{
    private Image thisButton;
    public Color enabledColor;
    public Color disabledColor;
    public Sprite EnabledSprite;
    public Sprite DisabledSprite;

    private void Start()
    {
        thisButton = GetComponent<Image>();
        if (PlayerPrefs.GetInt("Musica") == 1)
        {
            thisButton.color = enabledColor;
            thisButton.overrideSprite = EnabledSprite;
        }
        else
        {
            thisButton.color = disabledColor;
            thisButton.overrideSprite = DisabledSprite;
        }
    }


    void Update()
    {
        if (PlayerPrefs.GetInt("Musica") == 1)
        {
            thisButton.color = enabledColor;
            thisButton.overrideSprite = EnabledSprite;
        }
        else
        {
            thisButton.color = disabledColor;
            thisButton.overrideSprite = DisabledSprite;
        }
    }
}
