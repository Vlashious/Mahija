using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommonEnums
{
    public enum ElementType
    {
        Matter,
        Life,
        Spirit,
        Void
    }

    public class ElementTypeExtension
    {
        public static ElementType[] ElementTypes = (ElementType[])Enum.GetValues(typeof(ElementType));
    }
}