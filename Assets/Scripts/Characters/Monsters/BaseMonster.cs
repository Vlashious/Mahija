using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;

namespace Characters
{
    public abstract class BaseMonster : BaseCharacter
    {
        protected GameObject _player;
        protected override void Init()
        {
            base.Init();
            _player = MainController.Instance.BattleController.Player;
        }
    }
}