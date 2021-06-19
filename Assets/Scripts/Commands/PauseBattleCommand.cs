using UnityEngine;

namespace Commands
{
    public class PauseBattleCommand : ICommand
    {
        private float _previousTimeScale;
        public void Execute()
        {
            _previousTimeScale = Time.timeScale;
            Time.timeScale = 0;
        }

        public void Undo()
        {
            Time.timeScale = _previousTimeScale;
        }
    }
}