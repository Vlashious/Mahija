using System;
using System.Collections.Generic;
using Magic.Elements;
using Magic.Spells;

namespace Data
{
    public class PlayerData
    {
        public event Action<int> ScoreChanged;
        public event Action SpellStupChanged;
        public int PlayerScore
        {
            get => _playerScore;
            set
            {
                _playerScore = value;
                ScoreChanged?.Invoke(_playerScore);
            }
        }

        public Dictionary<BaseSpell, IElement[]> SpellSetup
        {
            get => _spellSetup;
            set
            {
                _spellSetup = value;

            }
        }

        private int _playerScore;
        private Dictionary<BaseSpell, IElement[]> _spellSetup;
    }
}
