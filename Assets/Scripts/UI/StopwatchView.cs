using UnityEngine;

public class StopwatchView : View
{
    [SerializeField] private Stopwatch _stopwatch;

    private readonly string TIME = "�����:";

    private void OnEnable()
    {
        _stopwatch.LevelEnded += OnLevelEnded;
    }

    private void OnDisable()
    {
        _stopwatch.LevelEnded -= OnLevelEnded;
    }

    private void OnLevelEnded()
    {
        UpdateText(TIME, _stopwatch.SessionTime);
    }
}
