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
        }

        private AutoAttackInfo _info;
        private Vector3 _dir;

        [Inject]
        public void Init(AutoAttackInfo info)
        {
            transform.position = info.Origin;

            _dir = info.Target - info.Origin;

            // TODO: rotate missile, follow direction
            var angle = Vector3.SignedAngle(transform.position, _dir, Vector3.forward);
            transform.right = _dir;
        }

        protected override void Act()
        {
            Rigidbody.MovePosition(transform.position + _dir * (Config.AutoAttackSpeed * Time.fixedDeltaTime));
        }

        protected override void OnCollision(Collision2D other)
        {
            Debug.Log($"Collided with {other.gameObject.name}");
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

        public class Factory : PlaceholderFactory<AutoAttackInfo, AutoAttack>
        {
        }
    }
}