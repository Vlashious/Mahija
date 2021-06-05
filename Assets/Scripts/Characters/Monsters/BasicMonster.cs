using UnityEngine;
using Zenject;

namespace Characters
{
    public class BasicMonster : BaseMonster
    {
        [Inject]
        protected void Init()
        {
            MovementSpeed = 200;
        }

        protected override void Act()
        {
        }

        protected override void Move()
        {
            var oldPos = transform.position;
            var playerPos =_player.transform.position;
            var moveVector = (playerPos - oldPos).normalized;

            Rigidbody.MovePosition(oldPos + new Vector3(moveVector.x * MovementSpeed, moveVector.y * MovementSpeed) *
                Time.fixedDeltaTime);
        }

        public class Factory : PlaceholderFactory<BasicMonster>
        {
        }
    }
}