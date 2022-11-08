using UnityEngine;

[RequireComponent(typeof(Ball))]
public class BallCollisionHandler : MonoBehaviour
{
    private Ball _ball;

    private void Start()
    {
        _ball = GetComponent<Ball>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _ball.Die();
    }
}