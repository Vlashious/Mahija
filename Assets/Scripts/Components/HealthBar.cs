using System.Collections;
using System.Collections.Generic;
using Characters;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Components
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _progressBar;
        [Inject]
        public void Init(MainCharacter player)
        {
            player.HpChanged += OnPlayerHpChanged;
            _progressBar.fillAmount = player.HP / player.MaxHP;
        }

        private void OnPlayerHpChanged(float currentHp, float maxHp)
        {
            _progressBar.fillAmount = currentHp / maxHp;
        }
    }
}
