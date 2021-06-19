using Controllers;
using Zenject;

namespace Windows
{
    public class MainHudWindow : BaseWindow
    {
        [Inject] private CommandController _commandController;

        public void OnStartBattleClick()
        {
            _commandController.ExecuteCommand(CommonEnums.CommandType.EnterTheBattle);
        }
    }
}