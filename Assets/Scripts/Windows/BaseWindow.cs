using Controllers;
using UnityEngine;
using Zenject;

namespace Windows
{
    public class BaseWindow : MonoBehaviour
    {
        [Inject] protected CommandController _commandController;
        public class BaseWindowData
        {
        }

        public virtual void Open()
        {
        }

        public virtual void Close()
        {
        }
    }
}