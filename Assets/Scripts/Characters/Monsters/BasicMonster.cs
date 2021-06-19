using UnityEngine;
using Zenject;

namespace Characters
{
    public class BasicMonster : BaseMonster
    {
        public struct BasicMonsterInfo
        {
            public Vector3 StartPosition;
        }

        [Inject]
        protected void Init(BasicMonsterInfo info)
        {
            transform.position = info.StartPosition;
        }

        protected override void Act()
        {
        }

        protected override void Move()
        {
            var oldPos = transform.position;
            var playerPos = _player.transform.position;
            var moveVector = (playerPos - oldPos).normalized;

            Rigidbody.MovePosition(oldPos +
                                   new Vector3(moveVector.x * Config.BasicMonsterSpeed,
                                       moveVector.y * Config.BasicMonsterSpeed) *
                                   Time.fixedDeltaTime);
        }

        protected override void OnCollision(Collision2D info)
        {
            if(info.gameObject.TryGetComponent<MainCharacter>(out var player))
            {
                player.HP -= Config.BasicMonsterDamage;
            }
        }

        public class Factory : PlaceholderFactory<BasicMonsterInfo, BasicMonster>
        {
        }
    }
}