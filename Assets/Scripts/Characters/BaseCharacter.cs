using System;
using Controllers;
using UnityEngine;
using Zenject;

namespace Characters
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class BaseCharacter : MonoBehaviour
    {
        public event Action<float, float> HpChanged;
        public event Action Died;

        public float HP
        {
            get => _hp;
            set
            {
                _hp = value;
                HpChanged?.Invoke(_hp, _maxHp);

                if (value <= 0)
                {
                    Died?.Invoke();
                }
            }
        }

        protected Rigidbody2D Rigidbody;
        protected Animator Animator;
        [Inject] protected CharacterConfig Config;
        [Inject] private EventController _eventController;
        protected float _hp;
        protected float _maxHp;

        private void Awake()
        {
            Animator = GetComponent<Animator>();
            Rigidbody = GetComponent<Rigidbody2D>();
            _eventController.OnUpdate += Act;
            _eventController.OnFixedUpdate += Move;
            Died += Die;
        }

        protected virtual void Act()
        {
        }

        protected virtual void Move()
        {
        }

        protected virtual void Die()
        {
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            OnCollision(other);
        }

        protected virtual void OnCollision(Collision2D other)
        {
        }

        private void OnDestroy()
        {
            _eventController.OnUpdate -= Act;
            _eventController.OnFixedUpdate -= Move;
        }
    }
}