using UnityEngine;

namespace Magic
{
    [CreateAssetMenu(fileName = "SpellConfig", menuName = "ScriptableObjects/Spells", order = 1)]
    public class SpellConfig : ScriptableObject
    {
        public float AutoAttackRange;
        public float AutoAttackCooldown;
        public float AutoAttackSpeed;
    }
}
