using System;
using System.Collections;
using Pong.BallBehavior;
using UnityEngine;

namespace Pong.MatchSystem
{
    public class MatchProgressionController : MonoBehaviour
    {
        [SerializeField] private BallDeathSender ballDeathSender;
        [SerializeField] private BallMovement ballMovement;
        [SerializeField] private float secondsToStartMatch = 1f;

        public static event Action<int, bool> OnScoreChanged = delegate { };

        private readonly PlayerScore _leftPlayerScore = new();
        private readonly PlayerScore _rightPlayerScore = new();

        private void Start()
        {
            StartCoroutine(StartMatch());
        }

        private void OnEnable()
        {
            ballDeathSender.OnBallDeath += HandleBallDeath;
        }

        private void OnDisable()
        {
            ballDeathSender.OnBallDeath -= HandleBallDeath;
        }

        private void HandleBallDeath(bool damagesLeftPlayer)
        {
            PlayerScore playerScore = GetPlayerScore(!damagesLeftPlayer);
            playerScore.IncreaseScore();
            
            OnScoreChanged(playerScore.Score, !damagesLeftPlayer);
            StartCoroutine(StartMatch());
        }

        private IEnumerator StartMatch()
        {
            ballMovement.ResetPosition();
            yield return new WaitForSeconds(secondsToStartMatch);
            ballMovement.StartMovingToRandomDirection();
        }

        private PlayerScore GetPlayerScore(bool isLeftPlayer)
        {
            return isLeftPlayer ? _leftPlayerScore : _rightPlayerScore;
        }
    }
}