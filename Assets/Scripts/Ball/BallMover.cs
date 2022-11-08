using UnityEngine;

public class BallMover : MonoBehaviour
{
    [SerializeField] private MovementOptions _options;

    private BallInputButton _inputButton;
    private Stopwatch _stopwatch;
    private float _currentVerticalSpeed;
    private Vector3 _startPosition;
    private bool _isButtonPressed;
    private DifficultyType _type;

    private void OnDisable()
    {
        _inputButton.ButtonPressed -= OnButtonPressed;
        _inputButton.UpButtonReleased -= OnButtonReleased;
        _stopwatch.MultiplyVerticalSpeed -= OnMultiplyVerticalSpeed;
    }

    public void Init(BallInputButton inputButton, Stopwatch stopwatch, DifficultyType type)
    {
        _inputButton = inputButton;
        _stopwatch = stopwatch;

        _stopwatch.MultiplyVerticalSpeed += OnMultiplyVerticalSpeed;
        _inputButton.ButtonPressed += OnButtonPressed;
        _inputButton.UpButtonReleased += OnButtonReleased;

        _startPosition = transform.position;
        ChangeVerticalSpeed(type);
        ResetBall();
    }

    public void ChangeVerticalSpeed(DifficultyType type)
    {
        _type = type;
        SetVerticalSpeed(GetVerticalSpeed(type));
    }

    public void ResetBall()
    {
        SetVerticalSpeed(GetVerticalSpeed(_type));
        transform.position = _startPosition;
    }

    private void Update()
    {
        if (_isButtonPressed)
            Move(_currentVerticalSpeed);
        else
            Move(-_currentVerticalSpeed);
    }

    private void Move(float verticalSpeed)
    {
        transform.Translate(new Vector3(_options.HorizontalSpeed, verticalSpeed, 0f) * Time.deltaTime);
    }

    private void OnButtonPressed()
    {
        _isButtonPressed = true;
    }

    private void OnButtonReleased()
    {
        _isButtonPressed = false;
    }

    private void OnMultiplyVerticalSpeed()
    {
        float speed = _currentVerticalSpeed * _options.SpeedMultiplier;

        if (speed >= _options.LimitVerticalSpeed)
            speed = _options.LimitVerticalSpeed;

        SetVerticalSpeed(speed);
    }

    private void SetVerticalSpeed(float speed)
    {
        _currentVerticalSpeed = speed;
    }

    private float GetVerticalSpeed(DifficultyType type)
    {
        if (type == DifficultyType.Normal)
            return _options.NormalVerticalSpeed;
        else if (type == DifficultyType.Hard)
            return _options.HardVerticalSpeed;

        return _options.EasyVerticalSpeed;
    }
}