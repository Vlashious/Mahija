using System.Collections;
using System.Collections.Generic;
using CommonEnums;
using Data;
using UnityEngine;
using Zenject;

namespace Commands
{

    public class AddElementToSpellCommand : ICommandWithParameter
    {
        [Inject] private PlayerData _playerData;
        public void Execute(CommandParameter parameter)
        {
            var param = (AddElementToSpellParameter)parameter;
            if (_playerData.SpellSetup.ContainsKey(param.Spell))
            {
                _playerData.SpellSetup[param.Spell].Add(param.Element);
            }
        }

        public class AddElementToSpellParameter : CommandParameter
        {
            public SpellType Spell;
            public ElementType Element;
        }
    }
}
