using UnityEngine;

namespace _Scripts.InputHandler
{
    public class PlayerMovementController
    {
        private readonly Transform _playerTransform;
        private readonly float _moveSpeed;
        
        public PlayerMovementController(Transform playerTransform,float moveSpeed)
        {
            _playerTransform = playerTransform;
            _moveSpeed = moveSpeed;
        }

        public void MovePlayer(float horizontalInput, float verticalInput)
        {
            Vector3 movement = new Vector3(horizontalInput,verticalInput,0).normalized;
            _playerTransform.position += movement * _moveSpeed * Time.deltaTime;
        }
    }
}