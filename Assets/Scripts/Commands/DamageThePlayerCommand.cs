using System.Collections;
using System.Collections.Generic;
using Characters;
using UnityEngine;
using Zenject;

namespace Commands
{
    public class DamageThePlayerCommand : ICommand
    {
        [Inject] MainCharacter _player;
        [Inject] CharacterConfig _config;
        public void Execute()
        {
            _player.HP -= _config.BasicMonsterDamage;
        }

        public void Undo()
        {
            
        }
    }

}