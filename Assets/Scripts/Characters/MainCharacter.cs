using UnityEngine;
using Zenject;

namespace Characters
{
    public class MainCharacter : BaseCharacter
    {
        private Vector2 _lastMoveDir;
        private float _speed;

        [Inject]
        protected void Init(CharacterConfig config)
        {
            _speed = config.MainCharacterSpeed;
            _maxHp = config.MainCharacterMaxHp;
        }

        protected override void Act()
        {
        }

        protected override void Move()
        {
            var oldPos = transform.position;
            var h = Input.GetAxisRaw("Horizontal");
            var v = Input.GetAxisRaw("Vertical");
            Animator.SetFloat("hMove", _lastMoveDir.x);

            if (!Mathf.Approximately(h, 0) || !Mathf.Approximately(v, 0))
            {
                Animator.SetBool("IsMoving", true);
                _lastMoveDir = new Vector2(h, v);
                var moveDirNormalized = _lastMoveDir.normalized;

                Rigidbody.MovePosition(oldPos + new Vector3(moveDirNormalized.x * _speed,
                moveDirNormalized.y * _speed) * Time.fixedDeltaTime);
            }
            else
            {
                Animator.SetBool("IsMoving", false);
            }
        }
    }
}