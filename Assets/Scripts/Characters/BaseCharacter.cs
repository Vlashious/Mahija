using System;
using Controllers;
using UnityEngine;
using Zenject;

namespace Characters
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class BaseCharacter : MonoBehaviour
    {
        public event Action HpChanged;
        public event Action Died;

        public int HP
        {
            get => _hp;
            set
            {
                _hp = value;
                HpChanged?.Invoke();

                if (value <= 0)
                {
                    Died?.Invoke();
                }
            }
        }

        protected Rigidbody2D Rigidbody;
        protected Animator Animator;
        [Inject] protected CharacterConfig Config;
        private int _hp;

        private void Awake()
        {
            Animator = GetComponent<Animator>();
            Rigidbody = GetComponent<Rigidbody2D>();
            MainController.OnUpdate += Act;
            MainController.OnFixedUpdate += Move;
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

        private void OnDestroy()
        {
            MainController.OnUpdate -= Act;
            MainController.OnFixedUpdate -= Move;
        }
    }
}