using System;
using Windows;
using CommonEnums;
using UnityEngine;
using Zenject;
using Data;
using ScriptableObjects;

namespace Installers
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private WindowDeclaration[] _windows;
        [SerializeField] private Transform _windowRoot;
        [SerializeField] private ElementTinterConfig _tintConfig; 

        public override void InstallBindings()
        {
            foreach (var windowDeclaration in _windows)
            {
                Container.Bind<BaseWindow>().WithId(windowDeclaration.WindowType)
                    .FromComponentInNewPrefab(windowDeclaration.WindowPrefab)
                    .UnderTransform(_windowRoot).AsCached().NonLazy();
            }

            Container.Bind<WindowManager>().AsSingle().NonLazy();
            Container.Bind<PlayerData>().AsSingle().NonLazy();
            Container.Bind<ElementTinterConfig>().FromNewScriptableObject(_tintConfig).AsSingle();
        }

        [Serializable]
        public struct WindowDeclaration
        {
            public WindowType WindowType;
            public BaseWindow WindowPrefab;
        }
    }
}