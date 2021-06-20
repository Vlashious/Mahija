using System.Collections.Generic;
using Controllers;
using Magic.Elements;
using UnityEngine;
using Zenject;

namespace Magic.Spells
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class BaseSpell : MonoBehaviour
    {
        protected List<IElement> Elements;
        [Inject] protected SpellConfig Config;
        [Inject] protected EventController _eventController;

        private void Awake()
        {
            _eventController.OnFixedUpdate += Act;
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