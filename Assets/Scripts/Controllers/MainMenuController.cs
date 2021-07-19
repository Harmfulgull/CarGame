
using UnityEngine;

public class MainMenuController : BaseController
{
    private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/MainMenu" };
    private readonly ProfilePlayer _profilePlayer;
    private readonly MainMenuView _mainMenuView;
    private MainMenuController _mainMenuController;
    private readonly Transform _placeForUI;
    private GameController _gameController;


    public MainMenuController(Transform placeForUI, ProfilePlayer profilePlayer)
    {
        _profilePlayer = profilePlayer;
        _mainMenuView = LoadView(placeForUI);
        _mainMenuView.Init(StartGame);
        OnChangeState(_profilePlayer.CurrentState.Value);
        profilePlayer.CurrentState.SubscribeOnChange(OnChangeState);

    }

    private MainMenuView LoadView(Transform placeForUI)
    {
        var @object = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUI);
        AddGameObject(@object);
        return @object.GetComponent<MainMenuView>();
    }

    private void StartGame()
    {
        _profilePlayer.CurrentState.Value = GameState.Game;
    }

    //protected override void OnDisponse()
    //{
    //    _mainMenuView.ButtonStart.onClick.RemoveAllListeners();
    //    base.OnDisponse();
    //}

    private void OnChangeState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                _mainMenuController = new MainMenuController(_placeForUI, _profilePlayer);
                _gameController?.Dispose();
                break;
            case GameState.Game:
                _gameController = new GameController(_profilePlayer);
                _mainMenuController?.Dispose();
                break;
            default:
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                break;

        }
    }
}
