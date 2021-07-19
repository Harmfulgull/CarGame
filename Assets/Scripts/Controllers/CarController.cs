using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : BaseController
{
    private readonly ResourcePath _viewPath = new ResourcePath { PathResource  = "Prefabs/Car"};
    private readonly CarView _carView;

    public CarController()
    {
        _carView = LoadView();
    }

    public GameObject GetView()
    {
        return _carView.gameObject;
    }

    private CarView LoadView()
    {
        var objectCar = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
        AddGameObject(objectCar);
        return objectCar.GetComponent<CarView>();
    }


}
