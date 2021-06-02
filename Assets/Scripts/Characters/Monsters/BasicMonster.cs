using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    public class BasicMonster : BaseMonster
    {
        protected override void Act()
        {
            Move();
        }

        private void Move()
        {
            var oldPos = transform.position;
            var playerPos = _player.transform.position;
            var moveVector = (playerPos - transform.position).normalized;

            transform.position = new Vector2(oldPos.x + moveVector.x * MovementSpeed,
                oldPos.y + moveVector.y * MovementSpeed);
        }
    }
}