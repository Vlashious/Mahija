using System;
using Controllers;
using UnityEngine;

namespace Characters
{
    public abstract class BaseCharacter : MonoBehaviour
    {
        [SerializeField]
        protected Animator _animator;
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
        private void Start()
        {
            MainController.Instance.OnUpdate += Act;
            Died += Die;
            Init();
        }

        protected virtual void Init()
        {
            _hp = 100;
            MovementSpeed = 10;
        }
        protected virtual void Act()
        {
        }
        protected virtual void Die()
        {
            Destroy(this);
        }
    }
}