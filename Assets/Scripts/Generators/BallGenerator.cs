using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallGenerator : ObjectPool
{
    [SerializeField] private Ball _prefab;
    [SerializeField] private BallInputButton _ballInputButton;
    [SerializeField] private BallTracker _tracker;
    [SerializeField] private List<DifficultySelection> _difficultySelections;
    [SerializeField] private Stopwatch _stopwatch;

    private Ball _ball;
    private DifficultyType _type;

    public Ball Ball => _ball;

    public event UnityAction GameOver;

    private void OnEnable()
    {
        for (int i = 0; i < _difficultySelections.Count; i++)
            _difficultySelections[i].DifficaltySelected += OnDifficaltySelected;
    }

    private void OnDisable()
    {
        if(_ball != null)
            _ball.Died -= OnDied;

        for (int i = 0; i < _difficultySelections.Count; i++)
            _difficultySelections[i].DifficaltySelected -= OnDifficaltySelected;
    }

    public override void StartGenerate()
    {
        Init(_prefab.gameObject, true);

        GameObject ballObject = GetFirstObject();

        if(ballObject.TryGetComponent(out Ball ball))
        {
            _ball = ball;
            ball.Init(_ballInputButton, _stopwatch, _type);
            ball.Died += OnDied;
            _tracker.Init(ball);
        }
        else
        {
            throw new ArgumentException(nameof(ball));
        }
    }

    private void OnDied()
    {
        GameOver?.Invoke();
    }

    private void OnDifficaltySelected(DifficultyType type)
    {
        _type = type;

        if(_ball != null)
            _ball.SetDifficultType(type);

        for (int i = 0; i < _difficultySelections.Count; i++)
            _difficultySelections[i].UpdateDropdown((int)type);
    }
}