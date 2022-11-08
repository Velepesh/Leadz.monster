using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BallMover))]
public class Ball : MonoBehaviour
{
    private BallMover _mover;

    public event UnityAction Died;

    public void Init(BallInputButton inputButton, Stopwatch stopwatch, DifficultyType type)
    {
        _mover = GetComponent<BallMover>();
        _mover.Init(inputButton, stopwatch, type);
    }

    public void ResetPlayer()
    {
        _mover.ResetBall();
    }

    public void Die()
    {
        Died?.Invoke();
    }

    public void SetDifficultType(DifficultyType type)
    {
        _mover.ChangeVerticalSpeed(type);
    }
}