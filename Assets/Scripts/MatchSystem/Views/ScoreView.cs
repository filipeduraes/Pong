using System;
using TMPro;
using UnityEngine;

namespace Pong.MatchSystem.View
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;

        private void Awake()
        {
            Populate(0);
        }

        public void Populate(int newScore)
        {
            scoreText.SetText(newScore.ToString());
        }
    }
}
