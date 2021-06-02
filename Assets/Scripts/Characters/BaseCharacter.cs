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

        public virtual void Init()
        {
            _hp = 100;
            MovementSpeed = 5;
            MainController.Instance.OnUpdate += Act;
            Died += Die;
        }

        protected virtual void Act()
        {
        }

        protected virtual void Die()
        {
        }
    }
}