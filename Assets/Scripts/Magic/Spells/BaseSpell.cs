using System.Collections.Generic;
using Controllers;
using Magic.Elements;
using UnityEngine;
using Zenject;

namespace Magic.Spells
{
    [RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
    public abstract class BaseSpell : MonoBehaviour
    {
        protected List<IElement> Elements;
        protected Rigidbody2D Rigidbody;
        [Inject] protected SpellConfig Config;

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            EventController.OnFixedUpdate += Act;
        }

        protected abstract void Act();

        private void OnCollisionEnter2D(Collision2D other)
        {
            OnCollision(other);
        }

        protected abstract void OnCollision(Collision2D other);

        private void OnDestroy()
        {
            EventController.OnFixedUpdate -= Act;
        }
    }
}