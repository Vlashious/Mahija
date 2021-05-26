using System;
using UnityEngine;
using Extensions;
namespace Controllers
{
    public class MainController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _playerPrefab;

        [SerializeField]
        private GameObject _monsterPrefab;

        public static MainController Instance { get; set; }
        public BattleController BattleController { get; set; }
        public event Action OnUpdate;
        private void Start()
        {
            Instance = this;
            StartBattle();
        }

        private void Update()
        {
            OnUpdate?.Invoke();
        }

        private void StartBattle()
        {
            BattleController = new BattleController();
            BattleController.Player = Instantiate(_playerPrefab);
            // Instantiate(_monsterPrefab, VectorExtensions.Randomize(1000, 1000), Quaternion.identity);
        }

        private void EndBattle()
        {
            BattleController = null;
        }
    }
}