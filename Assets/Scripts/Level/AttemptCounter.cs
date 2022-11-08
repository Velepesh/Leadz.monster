using UnityEngine;
using UnityEngine.Events;

public class AttemptCounter : MonoBehaviour
{
    private const string ATTEMPT_COUNTER = "AttemptCounter";

    public int _attemptCount
    {
        get { return PlayerPrefs.GetInt(ATTEMPT_COUNTER, 0); }
        set { PlayerPrefs.SetInt(ATTEMPT_COUNTER, value); }
    }

    public int AttemptCount => _attemptCount;

    public event UnityAction LevelEnded;

    public void Count()
    {
        _attemptCount = _attemptCount + 1;
        LevelEnded?.Invoke();
    }
}