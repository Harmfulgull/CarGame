using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfilePlayer 
{
    public SubscriptionProperty<GameState> CurrentState { get; }
    public Car CurrentCar { get; }
    public ProfilePlayer(float speed)
    {
        CurrentState = new SubscriptionProperty<GameState>();
        CurrentCar = new Car(speed);
    }

}
