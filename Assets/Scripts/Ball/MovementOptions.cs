using System;
using UnityEngine;

[Serializable]
public class MovementOptions
{
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _limitVerticalSpeed;
    [SerializeField] private float _easyVerticalSpeed;
    [SerializeField] private float _normalVerticalSpeed;
    [SerializeField] private float _hardVerticalSpeed;
    [SerializeField] private float _speedMultiplayer;

    public float HorizontalSpeed => _horizontalSpeed;
    public float LimitVerticalSpeed => _limitVerticalSpeed;
    public float EasyVerticalSpeed => _easyVerticalSpeed;
    public float NormalVerticalSpeed => _normalVerticalSpeed;
    public float HardVerticalSpeed => _hardVerticalSpeed;
    public float SpeedMultiplier => _speedMultiplayer;
}