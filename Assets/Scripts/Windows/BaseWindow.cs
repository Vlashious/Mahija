using UnityEngine;

namespace Windows
{
    public abstract class BaseWindow : MonoBehaviour
    {
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