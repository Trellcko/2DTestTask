using System;
using Trell.TwoDTestTask.Infrastructure.Service.UI;
using UnityEngine;

namespace Trell.TwoDTestTask.Infrastructure.Service
{
    public class PlayerInputService : MonoBehaviour, IPlayerInputService
    {
        [SerializeField] private ButtonWrapper _leftButton;
        [SerializeField] private ButtonWrapper _rightButton;
        [SerializeField] private ButtonWrapper _jumpButton;
        [SerializeField] private ButtonWrapper _fireButton;
        
        public event Action<int> MovementButtonPressed;
        public event Action MovementButtonReleased;
        public event Action JumpButtonClicked;
        public event Action FireButtonClicked;

        private void OnEnable()
        {
            _leftButton.Clicked += OnMovementButtonClicked;
            _rightButton.Clicked += OnMovementButtonClicked;
            _leftButton.Pressed += OnLeftButtonPressed;
            _rightButton.Pressed += OnRightButtonPressed;
            _jumpButton.Clicked += OnJumpButtonClicked;
            _fireButton.Clicked += OnFireButtonClicked;
        }

        private void OnDisable()
        {            
            _leftButton.Clicked -= OnMovementButtonClicked;
            _rightButton.Clicked -= OnMovementButtonClicked;
            _leftButton.Pressed -= OnLeftButtonPressed;
            _rightButton.Pressed -= OnRightButtonPressed;
            _jumpButton.Clicked -= OnJumpButtonClicked;
            _fireButton.Clicked -= OnFireButtonClicked;
        }

        private void OnMovementButtonClicked()
        {
            MovementButtonReleased?.Invoke();
        }

        private void OnFireButtonClicked()
        {
            FireButtonClicked?.Invoke();
        }

        private void OnJumpButtonClicked()
        {
            JumpButtonClicked?.Invoke();
        }

        private void OnRightButtonPressed()
        {
            OnMovementButtonPressed(1);
        }

        private void OnLeftButtonPressed()
        {
            OnMovementButtonPressed(-1);
        }
        
        

        private void OnMovementButtonPressed(int value)
        {
            MovementButtonPressed?.Invoke(value);
        }
    }
}
