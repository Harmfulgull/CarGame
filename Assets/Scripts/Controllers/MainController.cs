using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : BaseController
{
    private MainMenuController _mainMenuController;
    private GameController _gameController;
    private readonly Transform _placeForUi;
    private readonly ProfilePlayer _profilePlayer;
    private InventoryController _inventoryController;
    private readonly List<ItemConfig> _itemConfigs;
    public MainController(Transform placeForUi, ProfilePlayer profilePlayer, List<ItemConfig> itemConfigs)
    {
        _profilePlayer = profilePlayer;
        _placeForUi = placeForUi;
        OnChangeGameState(_profilePlayer.CurrentState.Value);
        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
        _itemConfigs = itemConfigs;

    }
    protected override void OnDispose()
    {
        AllClear();
        _profilePlayer.CurrentState.UnSubscribeOnChange(OnChangeGameState);
        base.OnDispose();
    }
    private void OnChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer);
                _gameController?.Dispose();
                break;
            case GameState.Game:
                _inventoryController = new InventoryController(_itemConfigs);
                _inventoryController.ShowInventory();

                _gameController = new GameController(_profilePlayer);
                _mainMenuController?.Dispose();
                break;
            default:
                AllClear();
                break;
        }
    }

    private void AllClear()
    {
        _inventoryController.Dispose();
        _mainMenuController?.Dispose();
        _gameController?.Dispose();
    }

}
