using System;
using Characters;
using UnityEngine;
using Extensions;

namespace Controllers
{
    public class MainController : MonoBehaviour
    {
        [SerializeField] private MainCharacter _playerPrefab;

        [SerializeField] private BaseMonster _monsterPrefab;

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
            BattleController.Player.Init();
            var m = Instantiate(_monsterPrefab, VectorExtensions.Randomize(1000, 1000), Quaternion.identity);
            m.Init();
        }

        private void EndBattle()
        {
            BattleController = null;
        }
    }
}