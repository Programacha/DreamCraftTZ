using System;
using _Scripts.Player;
using _Scripts.Weapon;

namespace _Scripts.InputHandler
{
    public class InputController : IDisposable
    {
        private readonly PlayerFireControl _playerFireControl;
        private readonly IInput _currentInput;
        private readonly PlayerMovementController _playerMovementController;
        private readonly WeaponHandler _weaponHandler;
        public InputController(PlayerMovementController playerMovementController, IInput input, PlayerFireControl playerFireControl,WeaponHandler weaponHandler)
        {
            _currentInput = input;
            _playerFireControl = playerFireControl;
            _playerMovementController = playerMovementController;
            _weaponHandler = weaponHandler;
        }
        
        public void Initialize()
        {
            SubscribeEvent();
        }
        
        public void Dispose()
        {
            UnsubscribeEvent();
        }
        
        private void SubscribeEvent()
        {
            _currentInput.OnShoot += _playerFireControl.Shot;
            _currentInput.OnMove += _playerMovementController.MovePlayer;
            _currentInput.OnTakeNewWeapon += _weaponHandler.SetUpNewWeapon;
        }
        
        private void UnsubscribeEvent()
        {
            _currentInput.OnShoot -= _playerFireControl.Shot;
            _currentInput.OnMove -= _playerMovementController.MovePlayer;
            _currentInput.OnTakeNewWeapon -= _weaponHandler.SetUpNewWeapon;
        }
    }
}