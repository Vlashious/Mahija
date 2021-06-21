using System.Collections.Generic;
using CommonEnums;
using Components;
using Controllers;
using UnityEngine;
using Zenject;

namespace Magic.Spells
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class BaseSpell : MonoBehaviour
    {
        protected ElementType _elementType;
        [SerializeField] private ElementTintPainter _elementTinter;
        [Inject] protected SpellConfig Config;
        [Inject] protected EventController _eventController;

        private void Awake()
        {
            _eventController.OnFixedUpdate += Act;
            _elementTinter.Init(_elementType);
        }

        protected abstract void Act();

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnCollision(other);
        }

        protected abstract void OnCollision(Collider2D other);

        private void OnDestroy()
        {
            _eventController.OnFixedUpdate -= Act;
        }
    }
}