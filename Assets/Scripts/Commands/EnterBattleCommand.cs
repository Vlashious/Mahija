using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using Windows;
using Zenject;

namespace Commands
{
    public class EnterBattleCommand : ICommand
    {
        [Inject] private WindowManager _windowManager;

        public void Execute()
        {
            _windowManager.OpenWindow(CommonEnums.WindowType.InBattleHud);
            _windowManager.CloseWindow(CommonEnums.WindowType.MainHud);
        }

        public void Undo()
        {
        }
    }
}
