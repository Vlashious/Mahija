using System;
using UnityEngine;

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
        _hp = 100;
        MovementSpeed = 10;
        MainController.Instance.OnUpdate += Act;
        Died += Die;
    }

    protected abstract void Act();
    protected virtual void Die()
    {
        Destroy(this);
    }
}
