using System;
using Windows;
using Controllers;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class UIManager : MonoInstaller
    {
        [SerializeField] private WindowDeclaration[] _windows;
        [SerializeField] private GameObject _dontDestroy;
        [SerializeField] private Transform _windowRoot;

        public static UIManager Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(_dontDestroy);
            EventController.BattleEnter += EnterBattle;
            EventController.BattleEnd += ExitBattle;

            OpenWindow(WindowType.MainHud);
        }

        public override void InstallBindings()
        {
            foreach (var windowDeclaration in _windows)
            {
                var windowType = windowDeclaration.WindowPrefab.GetType();
                Container.Bind(windowType).FromComponentInNewPrefab(windowDeclaration.WindowPrefab)
                    .UnderTransform(_windowRoot).AsSingle();

                Container.Bind<BaseWindow>().WithId(windowDeclaration.WindowType).To(windowType).FromResolve();
            }
        }

        private void OpenWindow(WindowType type)
        {
            var windowToOpen = Container.ResolveId<BaseWindow>(type);
            windowToOpen.gameObject.SetActive(true);
        }

        private void CloseWindow(WindowType type)
        {
            var windowToDestroy = Container.ResolveId<BaseWindow>(type);
            windowToDestroy.gameObject.SetActive(false);
        }

        private void EnterBattle()
        {
            CloseWindow(WindowType.MainHud);
            OpenWindow(WindowType.InBattleHud);
        }

        private void ExitBattle()
        {
            CloseWindow(WindowType.InBattleHud);
            OpenWindow(WindowType.MainHud);
        }

        [Serializable]
        public struct WindowDeclaration
        {
            public WindowType WindowType;
            public BaseWindow WindowPrefab;
        }
    }
}