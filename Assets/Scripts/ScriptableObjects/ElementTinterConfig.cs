using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "TinterConfig", menuName = "ScriptableObjects/TinterConfig", order = 1)]
    public class ElementTinterConfig : ScriptableObject
    {
        public Color MatterColor;
        public Color LifeColor;
        public Color SpiritColor;
        public Color VoidColor;
    }
}