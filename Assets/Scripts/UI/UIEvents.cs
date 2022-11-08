using UnityEngine;
using UnityEngine.Events;

public class UIEvents : MonoBehaviour
{
    [SerializeField] private Game _game;
    [SerializeField] private UnityEvent _onLevelStarted;
    [SerializeField] private UnityEvent _onGameLost;
    [SerializeField] private UnityEvent _onLevelRestart;


    private void OnEnable()
    {
        _game.LevelStarted += () => _onLevelStarted?.Invoke();
        _game.LevelLost += () => _onGameLost?.Invoke();
        _game.LevelRestart += () => _onLevelRestart?.Invoke();
    }

    private void OnDisable()
    {
        _game.LevelStarted -= () => _onLevelStarted?.Invoke();
        _game.LevelLost -= () => _onGameLost?.Invoke();
        _game.LevelRestart -= () => _onLevelRestart?.Invoke();
    }
}