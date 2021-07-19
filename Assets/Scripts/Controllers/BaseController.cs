﻿using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

public class BaseController : IDisposable
{
    private List<BaseController> _baseControllers = new List<BaseController>();
    private List<GameObject> _gameObjects = new List<GameObject>();
    private bool _isDisposed;
    public void Dispose()
    {
        if (!_isDisposed) return;
        _isDisposed = true;

        foreach(var baseController in _baseControllers)
            baseController?.Dispose();

        _baseControllers.Clear();

        foreach (var gameObject in _gameObjects)
            Object.Destroy(gameObject);

        _gameObjects.Clear();

        OnDisponse();
    }

    protected void AddController(BaseController baseController)
    {
        _baseControllers.Add(baseController);
    }

    protected void AddGameObject(GameObject gameObject)
    {
        _gameObjects.Add(gameObject);
    }

    protected virtual void OnDisponse()
    {

    }     
}