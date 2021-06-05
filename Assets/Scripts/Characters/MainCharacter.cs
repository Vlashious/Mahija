using UnityEngine;
using Zenject;

namespace Characters
{
    public class MainCharacter : BaseCharacter
    {
        private Vector2 _lastMoveDir;

        [Inject]
        protected void Init()
        {
            MovementSpeed = 300;
        }

        protected override void Act()
        {
        }

        protected override void Move()
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

                Rigidbody.MovePosition(oldPos + new Vector3(moveDirNormalized.x * MovementSpeed,
                    +moveDirNormalized.y * MovementSpeed) * Time.fixedDeltaTime);
            }
            else
            {
                _animator.SetBool("IsMoving", false);
            }
        }
    }
}