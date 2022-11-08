using UnityEngine;

public class BallTracker : MonoBehaviour
{
    [SerializeField] private float _xOffset;
    
    private Ball _ball;

    public void Init(Ball ball)
    {
        _ball = ball;
    }
    
    private void LateUpdate()
    {
        if (_ball != null)
            transform.position = new Vector3(_ball.transform.localPosition.x - _xOffset, transform.position.y, transform.position.z);
    }
}