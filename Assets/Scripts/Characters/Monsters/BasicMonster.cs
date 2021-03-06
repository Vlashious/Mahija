using CommonEnums;
using UnityEngine;
using Zenject;

namespace Characters
{
    public class BasicMonster : BaseMonster
    {
        public struct BasicMonsterInfo
        {
            public Vector3 StartPosition;
            public ElementType Element;
        }
        private float _damage;

        [Inject]
        protected void Init(BasicMonsterInfo info)
        {
            transform.position = info.StartPosition;
            Element = info.Element;
            _tintPainter.Init(Element);
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
            if (other.gameObject.TryGetComponent<MainCharacter>(out var player))
            {
                player.HP -= _damage;
            }
        }

        protected override void Die()
        {
            _commandController.ExecuteCommandWithParameter(CommonEnums.CommandType.AddScore, new Commands.AddScoreCommand.AddScoreParameter { ScoreToAdd = 5 });
            Destroy(gameObject);
        }

        public class Factory : PlaceholderFactory<BasicMonsterInfo, BasicMonster>
        {
        }
    }
}