using UnityEngine.SceneManagement;
using Windows;
using Zenject;

namespace Commands
{
    public class ExitBattleCommand : ICommand
    {
        [Inject] WindowManager _windowManager;
        public void Execute()
        {
            _windowManager.OpenWindow(CommonEnums.WindowType.MainHud);
            _windowManager.CloseWindow(CommonEnums.WindowType.InBattleHud);
            _windowManager.CloseWindow(CommonEnums.WindowType.InBattlePausePopup);
        }

        public void Undo()
        {
        }
    }

}