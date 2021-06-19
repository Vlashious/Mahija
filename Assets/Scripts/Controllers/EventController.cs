using System;
using UnityEngine;

namespace Controllers
{
    public class EventController : MonoBehaviour
    {
        public static event Action OnUpdate;
        public static event Action OnFixedUpdate;
        public static Action BattleEnter;
        public static Action BattleEnd;

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