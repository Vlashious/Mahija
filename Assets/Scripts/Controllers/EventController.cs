using System;
using UnityEngine;

namespace Controllers
{
    public class EventController : MonoBehaviour
    {
        public event Action OnUpdate;
        public event Action OnFixedUpdate;
        public Action BattleEnter;
        public Action BattleEnd;

        private void Update()
        {
            OnUpdate?.Invoke();
        }

        private void FixedUpdate()
        {
            OnFixedUpdate?.Invoke();
        }
    }
}