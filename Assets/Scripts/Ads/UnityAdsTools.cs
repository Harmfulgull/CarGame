using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsTools : MonoBehaviour, IAdsShower, IUnityAdsListener
{
    private const string _gameIdAndroid = "4228364";
    private const string _rewardPlacemenId = "rawardedVideo";
    private const string _bannerPlacemenId = "Banner";

    public void Start()
    {
        Advertisement.Initialize(_gameIdAndroid, true);
    }
    public void ShowBanner()
    {
        Advertisement.Show(_bannerPlacemenId);
    }

    public void ShowRewardedVideo()
    {
        Advertisement.Show(_rewardPlacemenId);
    }

    public void OnUnityAdsDidError(string message)
    {
        
    }

    public void OnUnityAdsDidStart(string placementId)
    {
       
    }

    public void OnUnityAdsReady(string placementId)
    {
       
    }
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Skipped)
            Debug.Log("Skipped");
    }

}
