using System;
using TMPro;
using UnityEngine;

namespace TheDark
{
    public class ScoreDisplay : MonoBehaviour
    {
        [SerializeField] private IntVariable currentScore;
        [SerializeField] private IntVariable startTime;

        private TextMeshProUGUI scoreText;
        private string startText;

        private void Start()
        {
            scoreText = GetComponent<TextMeshProUGUI>();
            startText = scoreText.text;

            UpdateScore();
        }

        public void UpdateScore() =>
            scoreText.SetText(string.Format(startText, 
                                            currentScore.RuntimeValue,
                                            startTime.InitialValue.SecondsToTimeString()));
    }
}