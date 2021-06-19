using Controllers;
using Zenject;

namespace Windows
{
    public class InBattlePausePopup : BaseWindow
    {
        [Inject] WindowManager _windowManager;
        [Inject] CommandController _commandController;
        public void OnResumeButtonClick()
        {
            _windowManager.CloseWindow(CommonEnums.WindowType.InBattlePausePopup);
            _commandController.UndoCommand(CommonEnums.CommandType.PauseTheBattle);
        }

        public void OnExitButtonClick()
        {
            _commandController.ExecuteCommand(CommonEnums.CommandType.ExitTheBattle);
        }
    }
}
