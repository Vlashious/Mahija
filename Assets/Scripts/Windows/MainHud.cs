using Controllers;

namespace Windows
{
    public class MainHud : BaseWindow
    {
        public void OnStartBattleClick()
        {
            EventController.BattleEnter?.Invoke();
        }
    }
}
