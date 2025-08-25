using System;
using UnityEngine;

namespace _Scripts.InputHandler
{
    public class DesktopInput : IInput
    {
        private const string HORIZONTAL = "Horizontal";
        private const string VERTICAL = "Vertical";
        
        public event Action OnShoot;
        public event Action<float, float> OnMove;
        public event Action<int> OnTakeNewWeapon;

        private int _weaponSlot = 0;
        
        private readonly GameSettings.GameSettings _gameSettings;

        public DesktopInput(GameSettings.GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
        }

        public void TakeShoot()
        {
            if (Input.GetMouseButton(0))
            {
                OnShoot?.Invoke();
            }
        }

        public void TakeMovement()
        {
            float horizontalInput = Input.GetAxisRaw(HORIZONTAL);
            float verticalInput = Input.GetAxisRaw(VERTICAL);
            
            OnMove?.Invoke(horizontalInput,verticalInput);
        }

        public void TakeNewWeapon()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (_weaponSlot > 0)
                {
                    _weaponSlot -= 1;
                    OnTakeNewWeapon?.Invoke(_weaponSlot);
                }
            }
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_weaponSlot < _gameSettings.Weapon.Length - 1)
                {
                    _weaponSlot += 1;
                    OnTakeNewWeapon?.Invoke(_weaponSlot);
                }
            }
        }

        public void Tick()
        {
            TakeShoot();
            TakeMovement();
            TakeNewWeapon();
        }
    }
}