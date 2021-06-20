using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InputModules
{
    public class JoystickInput : MonoBehaviour, IInputModule, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private RectTransform _origin;
        [SerializeField] private RectTransform _controller;
        private float _h;
        private float _v;
        private float _width;
        private float _height;
        private float _joystickRadius;

        private void Start()
        {
            _width = _origin.rect.width;
            _height = _origin.rect.height;

            _joystickRadius = _width / 2;
        }
        public Vector2 GetInput()
        {
            return new Vector2(_h, _v);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
        }

        public void OnDrag(PointerEventData eventData)
        {
            var dir = (Vector3)eventData.position - _origin.transform.position;
            var angle = Vector2.SignedAngle(Vector2.right, dir) * Mathf.Deg2Rad;
            if (dir.magnitude > _width / 2)
            {
                var kek = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                _controller.transform.position = (Vector2)_origin.transform.position + kek * _joystickRadius;
            }
            else
            {
                _controller.transform.position = eventData.position;
            }
            _h = dir.normalized.x;
            _v = dir.normalized.y;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _controller.position = _origin.transform.position;
            _h = 0;
            _v = 0;
        }
    }
}