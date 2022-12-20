using UnityEngine;

public class BallTraking : MonoBehaviour
{
    private Ball _ball;
    private Beam _beam;
    private Vector3 _objectPosition;
    private Vector3 _minimumBallPosition;
    [SerializeField] private float _lenght;
    [SerializeField] private Vector3 _directionOffSet;

    public void StartTraking()
    {
        _ball = FindObjectOfType<Ball>();
        _beam = FindObjectOfType<Beam>();
        _objectPosition = _ball.transform.position;
        _minimumBallPosition = _ball.transform.position;
        
        TrackBall();
    }

    private void Update()
    {
        if (_ball.transform.position.y < _minimumBallPosition.y)
        {
            TrackBall();
            _minimumBallPosition = _ball.transform.position;
        }
    }

    private void TrackBall()
    {
        Vector3 beamPosition = _beam.transform.position;
        beamPosition.y = _ball.transform.position.y;
        _objectPosition =_ball. transform.position; 
        Vector3 direction = (beamPosition -_ball.transform.position).normalized + _directionOffSet;
        _objectPosition -= direction * _lenght;
        transform.position = _objectPosition;
        transform.LookAt(_ball.transform);
    }
}
