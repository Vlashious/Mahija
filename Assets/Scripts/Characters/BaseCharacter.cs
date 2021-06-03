using System;
using Controllers;
using UnityEngine;

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
            Died += Die;
            Init();
        }

        protected virtual void Init()
        {
        }

        protected virtual void Act()
        {
        }

        protected virtual void Die()
        {
        }
    }
}