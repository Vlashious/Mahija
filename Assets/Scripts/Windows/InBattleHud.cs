using Controllers;

namespace Windows
{
    public class InBattleHud : BaseWindow
    {
        public void OnExitBattleClick()
        {
            EventController.BattleEnd?.Invoke();
        }
    }
}
