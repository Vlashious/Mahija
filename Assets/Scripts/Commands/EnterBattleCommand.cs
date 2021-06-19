using UnityEngine.SceneManagement;
using Windows;
using Zenject;

namespace Commands
{
    public class EnterBattleCommand : ICommand
    {
        [Inject] WindowManager _windowManager;
        public void Execute()
        {
            SceneManager.LoadScene(1);

            _windowManager.OpenWindow(CommonEnums.WindowType.InBattleHud);
            _windowManager.CloseWindow(CommonEnums.WindowType.MainHud);
        }

        public void Undo()
        {
        }
    }
}