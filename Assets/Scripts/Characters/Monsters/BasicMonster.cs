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

        private float _damage;

        [Inject]
        protected void Init(BasicMonsterInfo info)
        {
            transform.position = info.StartPosition;
            _maxHp = Config.BasicMonsterMaxHp;
            _hp = _maxHp;
            _speed = Config.BasicMonsterSpeed;
            _damage = Config.BasicMonsterBaseDamage;
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
                                   new Vector3(moveVector.x * _speed,
                                       moveVector.y * _speed) *
                                   Time.fixedDeltaTime);
        }

        protected override void OnCollision(Collision2D other)
        {
            if(other.gameObject.TryGetComponent<MainCharacter>(out var player))
            {
                player.HP -= _damage;
            }
        }

        public class Factory : PlaceholderFactory<BasicMonsterInfo, BasicMonster>
        {
        }
    }
}