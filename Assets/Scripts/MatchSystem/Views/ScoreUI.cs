using System;
using UnityEngine;

namespace Pong.MatchSystem.View
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private ScoreView leftScoreView;
        [SerializeField] private ScoreView rightScoreView;

        private void OnEnable()
        {
            MatchProgressionController.OnScoreChanged += PopulateScoreView;
        }

        private void OnDisable()
        {
            MatchProgressionController.OnScoreChanged -= PopulateScoreView;
        }

        private void PopulateScoreView(int newScore, bool isLeftPad)
        {
            ScoreView scoreView = isLeftPad ? leftScoreView : rightScoreView;
            scoreView.Populate(newScore);
        }
    }
}