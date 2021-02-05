using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSManager : MonoBehaviour
{
    //public Text FPSText;
    //public float deltaTime;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 144;
    }

    //private void Update()
    //{
    //    deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    //    float fps = 1.0f / deltaTime;
    //    FPSText.text = "FPS: " + Mathf.Ceil(fps).ToString();
    //}
}
