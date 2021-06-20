using Characters;
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

            var angle = Vector3.SignedAngle(transform.position, _dir, Vector3.forward);
            transform.right = _dir;
        }

        protected override void Act()
        {
            transform.Translate(Vector2.right * Config.AutoAttackSpeed);
        }

        protected override void OnCollision(Collider2D other)
        {
            Destroy(gameObject);
            if (other.gameObject.TryGetComponent<BaseCharacter>(out var character))
            {
                character.HP -= Config.AutoAttackBaseDamage;
            }
        }

        public class Factory : PlaceholderFactory<AutoAttackInfo, AutoAttack>
        {
        }
    }
}