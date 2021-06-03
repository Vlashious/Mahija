using UnityEngine;
using Zenject;

namespace Characters
{
    public abstract class BaseMonster : BaseCharacter
    {
        [Inject] protected GameObject _player;

        protected override void Init()
        {
            base.Init();
        }
    }
}