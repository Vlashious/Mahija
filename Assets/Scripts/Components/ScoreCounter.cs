using Data;
using TMPro;
using UnityEngine;
using Zenject;

namespace Components
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        
        [Inject]
        private void Init(PlayerData data)
        {
            data.ScoreChanged += UpdateScore;
            UpdateScore(data.PlayerScore);
        }

        private void UpdateScore(int newScore)
        {
            _scoreText.text = $"{newScore}";
        }
    }
}
