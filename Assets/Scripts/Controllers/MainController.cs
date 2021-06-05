using System;
using UnityEngine;

namespace Controllers
{
    public class MainController : MonoBehaviour
    {
        public static event Action OnUpdate;
        public static event Action OnFixedUpdate;

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