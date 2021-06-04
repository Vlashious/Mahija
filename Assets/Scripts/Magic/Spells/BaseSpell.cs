using Controllers;
using UnityEngine;

namespace Magic.Spells
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class BaseSpell : MonoBehaviour
    {
        private void Awake()
        {
            MainController.OnUpdate += Act;
        }

        protected abstract void Act();

        private void OnCollisionEnter2D(Collision2D other)
        {
            OnCollision(other);
        }

        protected abstract void OnCollision(Collision2D other);
    }
}