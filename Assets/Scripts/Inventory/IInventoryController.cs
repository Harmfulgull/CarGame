﻿
using System;

public interface IInventoryController 
{
    void ShowInventory();
    void ShowInventory(Action callback);
}
