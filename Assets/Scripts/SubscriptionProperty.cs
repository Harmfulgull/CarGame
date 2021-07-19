﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubscriptionProperty<T> : IReadOnlySubscriptionProperty<T>
{
    private T _value;
    private Action<T> _onChangeValue;
    public T Value 
    {
        get => _value;
        set
        {
            _value = value;
            _onChangeValue?.Invoke(_value);
        }
    }


    public void SubscribeOnChange(Action<T> subscribeOnChange)
    {
        _onChangeValue += subscribeOnChange;
    }

    public void UnSubscribeOnChange(Action<T> UnSubscribeOnChange)
    {
        _onChangeValue -= UnSubscribeOnChange;
    }
}
