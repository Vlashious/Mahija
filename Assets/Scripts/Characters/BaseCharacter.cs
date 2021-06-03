using System;
using Controllers;
using UnityEngine;
using Zenject;

namespace Characters
{
    public abstract class BaseCharacter : MonoBehaviour
    {
        [SerializeField] protected Animator _animator;
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

        protected float MovementSpeed;
        private int _hp;

        private void Awake()
        {
            MainController.OnUpdate += Act;
            MainController.OnUpdate += Move;
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
    }
}