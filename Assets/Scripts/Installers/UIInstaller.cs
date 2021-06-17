using System;
using Windows;
using CommonEnums;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private WindowDeclaration[] _windows;
        [SerializeField] private GameObject _dontDestroy;
        [SerializeField] private Transform _windowRoot;

        private void Awake()
        {
            DontDestroyOnLoad(_dontDestroy);
        }

        public override void InstallBindings()
        {
            foreach (var windowDeclaration in _windows)
            {
                Container.Bind<BaseWindow>().WithId(windowDeclaration.WindowType)
                    .FromComponentInNewPrefab(windowDeclaration.WindowPrefab)
                    .UnderTransform(_windowRoot).AsCached().NonLazy();
            }

            Container.Bind<WindowManager>().AsSingle().NonLazy();
        }

        [Serializable]
        public struct WindowDeclaration
        {
            public WindowType WindowType;
            public BaseWindow WindowPrefab;
        }
    }
}