using System;
using System.Collections;
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

        public void WaitAndExecute(float delay, Action callback)
        {
            StartCoroutine(WaitAndExecuteInternal(delay, callback));
        }

        private IEnumerator WaitAndExecuteInternal(float delay, Action callback)
        {
            yield return new WaitForSeconds(delay);
            callback?.Invoke();
        }
    }
}