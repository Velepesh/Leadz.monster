using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    [SerializeField] private List<ObjectPool> _pools;
    [SerializeField] private Stopwatch _stopwatch;
    [SerializeField] private AttemptCounter _counter;

    private BallGenerator _ballGenerator;
    private bool _isRestart = false;

    public event UnityAction LevelStarted;
    public event UnityAction LevelLost;
    public event UnityAction LevelRestart;

    private void OnDisable()
    {
        if(_ballGenerator != null)
            _ballGenerator.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        Time.timeScale = 0;
    }

    public void RestartLevel()
    {
        _isRestart = true;
        _ballGenerator.Ball.ResetPlayer();

        for (int i = 0; i < _pools.Count; i++)
        {
            if (_pools[i] is BallGenerator == false)
                _pools[i].ResetPool();
        }

        LevelRestart?.Invoke();
        
        StartLevel();
    }

    public void StartLevel()
    {
        Time.timeScale = 1;
        _stopwatch.StartStopwatch();
        
        if(_isRestart == false)
            StartGenerators();

        LevelStarted?.Invoke();
    }

    private void LoseGame()
    {
        _counter.Count();
        _stopwatch.StopStopwatch();
        LevelLost?.Invoke();
        Time.timeScale = 0;
    }

    private void StartGenerators()
    {
        for (int i = 0; i < _pools.Count; i++)
        {
            ObjectPool pool = _pools[i];

            if (_ballGenerator == null && pool is BallGenerator ballGenerator)
            {
                _ballGenerator = ballGenerator;
                _ballGenerator.GameOver += OnGameOver;
            }

            pool.StartGenerate();
        }

        if (_ballGenerator == null)
            throw new ArgumentException(nameof(_ballGenerator));
    }

    private void OnGameOver()
    {
        LoseGame();
    }
}