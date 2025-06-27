using System;
using Trell.TwoDTestTask.Infrastructure.Service;
using UnityEngine;
using Zenject;

namespace Trell.TwoDTestTask.Gameplay.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private Transform _checkGroundPoint;
        [SerializeField] private float _checkGroundRadius;
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;
        
        private IPlayerInputService _playerInputService;
        private IGroundCheckService _groundCheckService;
        
        private bool _isGrounded = true;

        #region Gizmos

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(_checkGroundPoint.position, _checkGroundRadius);
        }

        #endregion
        
        
        [Inject]
        private void Construct(IPlayerInputService playerInputService, IGroundCheckService groundCheckService)
        {
            Debug.Log("Inject" + (groundCheckService == null));
            _playerInputService = playerInputService;
            _groundCheckService = groundCheckService;
            Subscribe();
        }

        public void Init(float speed, float jumpForce)
        {
            _speed = speed;
            _jumpForce = jumpForce;
        }
        
        private void OnEnable()
        {
            Subscribe();
        }

        private void OnDisable()
        {
            UnSubscribe();
        }

        private void Subscribe()
        {
            if(_playerInputService == null)
                return;
            
            _playerInputService.MovementButtonPressed += OnMovementButtonPressed;
            _playerInputService.MovementButtonReleased += OnMovementButtonReleased;
            _playerInputService.JumpButtonClicked += OnJumpButtonClicked;
        }

        private void UnSubscribe()
        {
            _playerInputService.MovementButtonPressed -= OnMovementButtonPressed;
            _playerInputService.MovementButtonReleased -= OnMovementButtonReleased;
            _playerInputService.JumpButtonClicked -= OnJumpButtonClicked;
        }

        private void OnMovementButtonPressed(int direction)
        {
            UpdateXVelocity(direction * _speed);
        }

        private void OnMovementButtonReleased()
        {
            UpdateXVelocity(0);
        }

        private void OnJumpButtonClicked()
        {
            if(_groundCheckService.CheckForGround(_checkGroundPoint.position, _checkGroundRadius))
                _rigidbody2D.AddForce(_jumpForce * Vector2.up, ForceMode2D.Impulse);
        }

        private void UpdateXVelocity(float x)
        {
            _rigidbody2D.velocity = new(x, _rigidbody2D.velocity.y);

            Rotate(x);
        }

        private void Rotate(float x)
        {
            Debug.Log(x);
            if (x == 0)
                return;
            int direction = x > 0 ? -1 : 1;
            transform.parent.localScale = new(direction, 1, 1);
        }
    }
}
