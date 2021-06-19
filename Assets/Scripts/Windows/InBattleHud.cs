using Zenject;

namespace Windows
{
    public class InBattleHud : BaseWindow
    {
        [Inject] private WindowManager _windowManager;
        public void OnPauseButtonClick()
        {
            _commandController.ExecuteCommand(CommonEnums.CommandType.PauseBattle);
            _windowManager.OpenWindow(CommonEnums.WindowType.InBattlePausePopup);
        }
    }
}
