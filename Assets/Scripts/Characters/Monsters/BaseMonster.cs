using Controllers;
using UnityEngine;
using Zenject;

namespace Characters
{
    public abstract class BaseMonster : BaseCharacter
    {
        [Inject] protected MainCharacter _player;
    }
}