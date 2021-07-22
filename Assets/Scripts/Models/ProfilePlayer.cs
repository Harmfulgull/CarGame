using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ProfilePlayer 
{
    public SubscriptionProperty<GameState> CurrentState { get; }
    public Car CurrentCar { get; }
    public IAnaliticsTools AnaliticsTools { get; }
    public IAdsShower AdsShower { get; }
    public IUnityAdsListener AdsListener{ get; }
    public ProfilePlayer(float speed, UnityAdsTools unityAdsTools)
    {
        CurrentState = new SubscriptionProperty<GameState>();
        CurrentCar = new Car(speed);
        AnaliticsTools = new UnityAnaliticsTools();
        AdsShower = unityAdsTools;
        AdsListener = unityAdsTools;

    }

}
