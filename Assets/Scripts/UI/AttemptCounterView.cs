using UnityEngine;

public class AttemptCounterView : View
{
    [SerializeField] private AttemptCounter _attemptCounter;

    private readonly string ATTEMPT_COUNT = "Попыток:";
   
    private void OnEnable()
    {
        _attemptCounter.LevelEnded += OnLevelEnded;
    }

    private void OnDisable()
    {
        _attemptCounter.LevelEnded -= OnLevelEnded;
    }

    private void OnLevelEnded()
    {
        UpdateText(ATTEMPT_COUNT, _attemptCounter.AttemptCount);
    }
}