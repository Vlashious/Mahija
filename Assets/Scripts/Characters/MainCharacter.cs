using UnityEngine;

namespace Characters
{
    public class MainCharacter : BaseCharacter
    {
        private Vector2 _lastMoveDir;
        protected override void Init()
        {
            base.Init();
            MovementSpeed = 10;
        }

        protected override void Act()
        {
            Move();
        }

        private void Move()
        {
            var oldPos = transform.position;
            var h = Input.GetAxisRaw("Horizontal");
            var v = Input.GetAxisRaw("Vertical");
            _animator.SetFloat("hMove", _lastMoveDir.x);

            if (!Mathf.Approximately(h, 0) || !Mathf.Approximately(v, 0))
            {
                _animator.SetBool("IsMoving", true);
                _lastMoveDir = new Vector2(h, v);
                var moveDirNormalized = _lastMoveDir.normalized;

                transform.position = new Vector2(oldPos.x + moveDirNormalized.x * MovementSpeed, oldPos.y + moveDirNormalized.y * MovementSpeed);
            }
            else
            {
                _animator.SetBool("IsMoving", false);
            }
        }
    }
}