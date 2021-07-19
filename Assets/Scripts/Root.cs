using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{

    private Transform _placeForUi;

    private MainMenuController _mainMenuController;

    private void Awake()
    {
        var profilePlayer = new ProfilePlayer(15f);
        profilePlayer.CurrentState.Value = GameState.Start;
        _mainMenuController = new MainMenuController(_placeForUi, profilePlayer);
    }

    protected void OnDestroy()
    {
        _mainMenuController?.Dispose();
    }
}
