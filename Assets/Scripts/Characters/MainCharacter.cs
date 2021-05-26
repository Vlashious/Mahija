using UnityEngine;

public class MainCharacter : BaseCharacter
{
    private Vector2 _lastMoveDir;
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

            transform.position = new Vector2(oldPos.x + h * MovementSpeed, oldPos.y + v * MovementSpeed);
        }
        else
        {
            _animator.SetBool("IsMoving", false);
        }
    }
}
