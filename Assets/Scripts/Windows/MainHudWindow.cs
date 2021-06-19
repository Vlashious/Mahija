namespace Windows
{
    public class MainHudWindow : BaseWindow
    {
        public void OnStartBattleClick()
        {
            _commandController.ExecuteCommand(CommonEnums.CommandType.EnterBattle);
        }
    }
}