using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScaler : MonoBehaviour
{
    public float resX;
    public float resY;

    private CanvasScaler cS;

    void Start()
    {
        cS = GetComponent<CanvasScaler>();
        SetInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SetInfo()
    {
        resX = (float)Screen.currentResolution.width;
        resY = (float)Screen.currentResolution.height;

        cS.referenceResolution = new Vector2(resX,resY);
    }
}
