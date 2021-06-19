using Windows;
using CommonEnums;
using UnityEngine;
using Zenject;
using UnityEngine.SceneManagement;

namespace Commands
{
    public class InitLoadCommand : MonoBehaviour, ICommand
    {
        [Inject] private WindowManager _manager;

        private void Start()
        {
            Execute();
        }

        public void Execute()
        {
            _manager.OpenWindow(WindowType.MainHud);
        }

        public void Undo()
        {
        }
    }
}