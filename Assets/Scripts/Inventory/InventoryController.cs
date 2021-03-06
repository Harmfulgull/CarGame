using System;
using System.Collections.Generic;
using JetBrains.Annotations;

public class InventoryController : BaseController, IInventoryController
{
    private readonly IInventoryModel _inventoryModel;
    private readonly IInventoryView _inventoryView;
    private readonly ItemsRepository _upgradeItemsRepository;
    public IItemsRepository _itemsRepository { get; set; }
    private List<ItemConfig> itemConfigs { get; }
    public Action HideAction { get; }
    public InventoryController(List<ItemConfig> itemConfigs)
    {
        _inventoryModel = new InventoryModel();
        _inventoryView = new InventoryView();
        _itemsRepository = new ItemsRepository(itemConfigs);
        SubscribeView();
    }

    public InventoryController(InventoryModel inventoryModel, ItemsRepository upgradeItemsRepository)
    {
        _inventoryModel = inventoryModel;
        _upgradeItemsRepository = upgradeItemsRepository;
    }
    public void ShowInventory()
    {
        foreach (var item in _itemsRepository.Items.Values)
            _inventoryModel.EquipItem(item);

        var equippedItems = _inventoryModel.GetEquippedItems();
        _inventoryView.Display(equippedItems);
    }

    public void ShowInventory(Action callback)
    {

    }

    public void HideInventory()
    {
        _inventoryView.Hide();
        HideAction?.Invoke();
    }

    private void SubscribeView()
    {
        _inventoryView.Selected += OnItemSelected;
        _inventoryView.Deselected += OnItemDeselected;
    }

    protected override void OnDispose()
    {
        _inventoryView.Selected -= OnItemSelected;
        _inventoryView.Deselected -= OnItemDeselected;
        base.OnDispose();
    }

    private void OnItemSelected(IItem item)
    {
        _inventoryModel.EquipItem(item);
    }

    private void OnItemDeselected(IItem item)
    {
        _inventoryModel.UnEquipItem(item);
    }
}
