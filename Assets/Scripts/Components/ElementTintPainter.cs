using System.Collections;
using System.Collections.Generic;
using CommonEnums;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Components
{
    public class ElementTintPainter : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteToTint;
        [Inject] private ElementTinterConfig _tintConfig;
        public void Init(ElementType elementType)
        {
            switch (elementType)
            {
                case ElementType.Matter:
                    _spriteToTint.color = _tintConfig.MatterColor;
                    break;
                case ElementType.Life:
                    _spriteToTint.color = _tintConfig.LifeColor;
                    break;
                case ElementType.Spirit:
                    _spriteToTint.color = _tintConfig.SpiritColor;
                    break;
                case ElementType.Void:
                    _spriteToTint.color = _tintConfig.VoidColor;
                    break;
            }
        }
    }
}