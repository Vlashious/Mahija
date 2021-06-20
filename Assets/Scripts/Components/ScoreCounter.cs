using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Components
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        public int Score
        {
            get => _scoreValue;
            set
            {
                _scoreValue = value;
                UpdateScore();
            }
        }
        private int _scoreValue;

        private void UpdateScore()
        {
            _scoreText.text = $"{_scoreValue}";
        }
    }
}
