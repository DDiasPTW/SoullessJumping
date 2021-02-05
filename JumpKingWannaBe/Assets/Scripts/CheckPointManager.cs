using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Advertisements;


public class CheckPointManager : MonoBehaviour,IUnityAdsListener
{
    string placement = "rewardedVideo";
    GameObject player;
    static CheckPointManager instance;
    int numbCheck;

    private void Start()
    {
        Advertisement.Initialize("3653743", true);
        Advertisement.AddListener(this);
        
        player = GameObject.FindGameObjectWithTag("Player");
        numbCheck = player.GetComponent<PlayerMovementJumping>().numCheck;
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Update()
    {  
        player = GameObject.FindGameObjectWithTag("Player");
        numbCheck = player.GetComponent<PlayerMovementJumping>().numCheck;

        if (CrossPlatformInputManager.GetButtonUp("CheckPoint") && numbCheck == 0)
        {
            StartCoroutine(AddCheck());   
        }
    }

    IEnumerator AddCheck()
    {
        Advertisement.Initialize("3653743", true);
        //while (!Advertisement.IsReady(placement))
        //{
            
        //}
        if (!Advertisement.IsReady(placement))
        {
            Time.timeScale = 1;
            yield return null;
        }
        else if(Advertisement.IsReady(placement))
        {
            Advertisement.Show(placement);
            Time.timeScale = 0;
        }
        StopCoroutine(AddCheck());   
    }

    public void OnUnityAdsReady(string placementId)
    {
    }

    public void OnUnityAdsDidError(string message)
    {
        
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            player.GetComponent<PlayerMovementJumping>().numCheck++;
            Time.timeScale = 1;
        }
        else if (showResult == ShowResult.Failed)
        {
            //Bummer
            Time.timeScale = 1;
        }
    }
}
