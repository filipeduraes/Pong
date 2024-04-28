using System;
using UnityEngine;

namespace Pong.Pad
{
    public class PadMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D padBody;
        [SerializeField] private float moveSpeed = 1f;
        [SerializeField] private float maxMovement = 10f;
        
        private float _initialYPosition;

        private void Awake()
        {
            _initialYPosition = padBody.position.y;
        }

        private void FixedUpdate()
        {
            if (padBody.velocity.sqrMagnitude > 0f)
            {
                Vector2 currentPosition = padBody.position;

                if (Mathf.Abs(currentPosition.y - _initialYPosition) > maxMovement)
                {
                    StopMovement();

                    currentPosition.y = Mathf.Clamp(currentPosition.y, -maxMovement, maxMovement);
                    padBody.position = currentPosition;
                }
            }
        }

        public void StartMovement(int direction)
        {
            padBody.velocity = Vector2.up * (direction * moveSpeed);
        }

        public void StopMovement()
        {
            padBody.velocity = Vector2.zero;
        }
    }
}