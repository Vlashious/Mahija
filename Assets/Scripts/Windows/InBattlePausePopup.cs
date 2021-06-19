using Controllers;
using Zenject;

namespace Windows
{
    public class InBattlePausePopup : BaseWindow
    {
        public void OnExitButtonClick()
        {
            _commandController.ExecuteCommand(CommonEnums.CommandType.ExitBattle);
        }
    }
}
