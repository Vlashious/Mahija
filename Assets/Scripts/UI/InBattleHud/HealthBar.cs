using System.Collections;
using System.Collections.Generic;
using Characters;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.InBattleHud
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField]
        private Image _hpBar;

        [Inject]
        public void Init(MainCharacter player)
        {
            player.HpChanged += OnPlayerHpChanged;
        }

        private void OnPlayerHpChanged(float currentHP, float maxHP)
        {
            _hpBar.fillAmount = currentHP / maxHP;
        }
    }
}
