using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Trell.TwoDTestTask.UI
{
    [RequireComponent(typeof(Button))]
    public class ButtonWrapper : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private  Button _button;
        
        public event Action Clicked;
        public event Action Pressed;
        
        private bool _isPressed;
        
        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClicked);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClicked);
        }

        private void Update()
        {
            if (_isPressed)
            {
                InvokePressLogic();
                Pressed?.Invoke();
            }
        }

        public void Enable()
        {
            _button.interactable = true;
        }

        public void Disable()
        {
            _button.interactable = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _isPressed = true;
        }

        protected virtual void InvokeClickLogic(){ }

        protected virtual void InvokePressLogic(){}

        private void OnClicked()
        {
            InvokeClickLogic();
            Clicked?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isPressed = false;
        }
    }
}