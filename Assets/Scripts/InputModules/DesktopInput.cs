using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputModules
{
    public class DesktopInput : IInputModule
    {
        public Vector2 GetInput()
        {
            var h = Input.GetAxisRaw("Horizontal");
            var v = Input.GetAxisRaw("Vertical");

            return new Vector2(h, v);
        }
    }
}