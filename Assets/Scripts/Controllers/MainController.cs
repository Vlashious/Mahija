using System;
using UnityEngine;

namespace Controllers
{
    public class MainController : MonoBehaviour
    {
        public static event Action OnUpdate;

        private void Update()
        {
            OnUpdate?.Invoke();
        }
    }
}