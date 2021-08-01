using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbilityActivator
{
    GameObject GetViewObject();
}

public interface IAbility 
{
    void Applay(IAbilityActivator activator);
}

public interface IAbilityController
{
    void ShowAbilites();
}

