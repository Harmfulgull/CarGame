using System.Collections.Generic;
using System;

public interface IInventoryView 
{
    event Action<IItem> Selected;
    event Action<IItem> Deselected;
    void Display(IReadOnlyList<IItem> items);
    void Hide();
}
