using CommonEnums;
using Components;
using UnityEngine;
using Zenject;

namespace Characters
{
    public abstract class BaseMonster : BaseCharacter
    {
        [Inject] protected MainCharacter _player;
        [SerializeField] protected ElementTintPainter _tintPainter;
        public ElementType Element;
    }
}