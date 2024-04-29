using UnityEngine;
using Random = UnityEngine.Random;

namespace Pong.BallBehavior
{
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D ballBody;
        [SerializeField] private float velocity;
        [SerializeField] private LayerMask obstacleLayers;

        private Vector2 _initialPosition;
        private RaycastHit2D _hit;

        private void Start()
        {
            _initialPosition = ballBody.position;
        }

        private void Reset()
        {
            ballBody = GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _hit = Physics2D.Raycast(ballBody.position, ballBody.velocity, 1f, obstacleLayers);

            if (_hit)
                ballBody.velocity = Vector2.Reflect(ballBody.velocity, _hit.normal);
        }

        public void ResetPosition()
        {
            ballBody.position = _initialPosition;
            ballBody.velocity = Vector2.zero;
        }

        public void StartMovingToRandomDirection()
        {
            float xDirection = Mathf.Sign(Random.Range(-1f, 1f));
            float yDirection = Mathf.Sign(Random.Range(-1f, 1f));

            Vector2 direction = new(xDirection, yDirection);
            ballBody.velocity = direction * velocity;
        }
    }
}
