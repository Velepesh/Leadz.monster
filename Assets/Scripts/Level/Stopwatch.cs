using UnityEngine;
using UnityEngine.Events;

public class Stopwatch : MonoBehaviour
{
    readonly private float _secondsBetweenSpeedMultiplayer = 15f;
    private float _sessionTime = 0f;
    private float _elapsedTime = 0f;
    private bool _isStopwatch;

    public int SessionTime => (int)_sessionTime;

    public event UnityAction LevelEnded;
    public event UnityAction MultiplyVerticalSpeed;


    private void Update()
    {
        if (_isStopwatch)
        {
            _sessionTime += Time.deltaTime;

            _elapsedTime += Time.deltaTime;

            if(_elapsedTime >= _secondsBetweenSpeedMultiplayer)
            {
                _elapsedTime = 0f;
                MultiplyVerticalSpeed?.Invoke();
            }
        }
    }

    public void StartStopwatch()
    {
        ResetStopwatch();
        _isStopwatch = true;
    }

    public void StopStopwatch()
    {
        _isStopwatch = false;
        LevelEnded?.Invoke();
    }

    private void ResetStopwatch()
    {
        _elapsedTime = 0f;
        _sessionTime = 0f;
    }
}