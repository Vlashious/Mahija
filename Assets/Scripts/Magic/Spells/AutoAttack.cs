using UnityEngine;

namespace Magic.Spells
{
    public class AutoAttack : BaseSpell
    {
        protected override void Act()
        {
            
        }

        protected override void OnCollision(Collision2D other)
        {
            Debug.Log($"Collided with {other.gameObject.name}");
        }
    }
}
