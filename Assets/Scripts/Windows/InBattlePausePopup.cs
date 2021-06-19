using Controllers;
using Zenject;

namespace Windows
{
    public class InBattlePausePopup : BaseWindow
    {
        [Inject] WindowManager _windowManager;

        public void OnExitButtonClick()
        {
            _commandController.UndoCommand(CommonEnums.CommandType.PauseBattle);
            _commandController.ExecuteCommand(CommonEnums.CommandType.ExitBattle);
        }

        public void OnResumeButtonClick()
        {
            _commandController.UndoCommand(CommonEnums.CommandType.PauseBattle);
            _windowManager.CloseWindow(CommonEnums.WindowType.InBattlePausePopup);
        }
    }
}
