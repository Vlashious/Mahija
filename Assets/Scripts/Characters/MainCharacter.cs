using InputModules;
using UnityEngine;
using Zenject;

namespace Characters
{
    public class MainCharacter : BaseCharacter
    {
        private Vector2 _lastMoveDir;
        private IInputModule _input;

        [Inject]
        protected void Init(IInputModule input)
        {
            _input = input;
            _maxHp = Config.MainCharacterMaxHp;
            _hp = _maxHp;
            _speed = Config.MainCharacterSpeed;
        }

        protected override void Act()
        {
        }

        protected override void Move()
        {
            var input = _input.GetInput();
            var oldPos = transform.position;
            var h = input.x;
            var v = input.y;
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

        protected override void Die()
        {
            _commandController.ExecuteCommand(CommonEnums.CommandType.ExitBattle);
        }
    }
}