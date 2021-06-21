using System.Collections.Generic;
using Characters;
using CommonEnums;
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
            public ElementType Element;
        }

        private AutoAttackInfo _info;
        private Vector3 _dir;

        [Inject]
        public void Init(AutoAttackInfo info)
        {
            _elementType = info.Element;
            transform.position = info.Origin;

            _dir = info.Target - info.Origin;

            var angle = Vector3.SignedAngle(transform.position, _dir, Vector3.forward);
            transform.right = _dir;
            Destroy(gameObject, 5f);
        }

        protected override void Act()
        {
            transform.Translate(Vector2.right * Config.AutoAttackSpeed);
        }

        protected override void OnCollision(Collider2D other)
        {
            if (other.gameObject.TryGetComponent<BaseMonster>(out var monster))
            {
                if (monster.Element == _elementType)
                {
                    Destroy(gameObject);
                    monster.HP -= Config.AutoAttackBaseDamage;
                }
            }
        }

        public class Factory : PlaceholderFactory<AutoAttackInfo, AutoAttack>
        {
        }
    }
}