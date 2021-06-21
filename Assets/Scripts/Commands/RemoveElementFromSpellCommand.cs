using CommonEnums;
using Data;
using Magic.Spells;
using Zenject;

namespace Commands
{

    public class RemoveElementFromSpellCommand : ICommandWithParameter
    {
        [Inject] private PlayerData _playerData;
        public void Execute(CommandParameter parameter)
        {
            var param = (RemoveElementFromSpellParameter)parameter;
            if (_playerData.SpellSetup.ContainsKey(param.Spell))
            {
                _playerData.SpellSetup[param.Spell].Remove(param.Element);
            }
        }

        public class RemoveElementFromSpellParameter : CommandParameter
        {
            public SpellType Spell;
            public ElementType Element;
        }
    }
}
