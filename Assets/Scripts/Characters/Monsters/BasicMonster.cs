using UnityEngine;
using Zenject;

namespace Characters
{
    public class BasicMonster : BaseMonster
    {
        [Inject]
        protected void Init()
        {
            MovementSpeed = 6;
        }

        protected override void Act()
        {
        }

        protected override void Move()
        {
            var oldPos = transform.position;
            var playerPos = _player.transform.position;
            var moveVector = (playerPos - oldPos).normalized;

            transform.position = new Vector2(oldPos.x + moveVector.x * MovementSpeed,
                oldPos.y + moveVector.y * MovementSpeed);
        }
    }
}