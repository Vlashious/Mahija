using Controllers;
using Zenject;

namespace Windows
{
    public class InBattleHud : BaseWindow
    {
        [Inject] WindowManager _windowManager;
        [Inject] CommandController _commandController;
        public void OnPauseButtonClick()
        {
            _windowManager.OpenWindow(CommonEnums.WindowType.InBattlePausePopup);
            _commandController.ExecuteCommand(CommonEnums.CommandType.PauseTheBattle);
        }
    }
}
