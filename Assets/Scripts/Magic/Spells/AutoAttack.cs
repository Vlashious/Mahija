using UnityEngine;
using Zenject;

namespace Magic.Spells
{
    public class AutoAttack : BaseSpell
    {
        public struct AutoAttackInfo
        {
            public Vector3 Origin;
            public Vector3 Target;
            public float Speed;
        }

        private AutoAttackInfo _info;
        private Vector3 _dir;

        [Inject]
        public void Init(AutoAttackInfo info)
        {
            Debug.Log(info.Origin);
            Debug.Log(info.Target);
            transform.position = info.Origin;
            _info.Speed = info.Speed;

            _dir = info.Target - info.Origin;
            
            // TODO: rotate missile, follow direction
        }

        protected override void Act()
        {
            Rigidbody.MovePosition(transform.position + _dir * (_info.Speed * Time.fixedDeltaTime));
        }

        protected override void OnCollision(Collision2D other)
        {
            Debug.Log($"Collided with {other.gameObject.name}");
            Destroy(gameObject);
        }

        public class Factory : PlaceholderFactory<AutoAttackInfo, AutoAttack>
        {
        }
    }
}