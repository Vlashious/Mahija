using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Windows;
using Zenject;

namespace Commands
{
    public class ExitBattleCommand : ICommand
    {
        [Inject] private WindowManager _windowManager;
        public void Execute()
        {
            SceneManager.LoadScene("UI");

            _windowManager.CloseWindow(CommonEnums.WindowType.InBattleHud);
            _windowManager.CloseWindow(CommonEnums.WindowType.InBattlePausePopup);
            _windowManager.OpenWindow(CommonEnums.WindowType.MainHud);
        }

        public void Undo()
        {
        }
    }
}