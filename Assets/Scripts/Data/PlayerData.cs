using System;
using System.Collections.Generic;
using CommonEnums;

namespace Data
{
    public class PlayerData
    {
        public event Action<int> ScoreChanged;
        public event Action SpellSetupChanged;
        public int PlayerScore
        {
            get => _playerScore;
            set
            {
                _playerScore = value;
                ScoreChanged?.Invoke(_playerScore);
            }
        }

        public Dictionary<SpellType, List<ElementType>> SpellSetup
        {
            get => _spellSetup;
            set
            {
                _spellSetup = value;
                SpellSetupChanged?.Invoke();
            }
        }

        private int _playerScore;
        private Dictionary<SpellType, List<ElementType>> _spellSetup = new Dictionary<SpellType, List<ElementType>>()
        {
            {SpellType.AutoAttack, new List<ElementType>() {ElementType.Matter, ElementType.Life, ElementType.Spirit}}
        };
    }
}
