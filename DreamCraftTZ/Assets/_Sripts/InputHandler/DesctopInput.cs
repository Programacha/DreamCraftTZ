using System;
using GameSystem;
using UnityEngine;

namespace _Sripts.InputHandler
{
    public class DesktopInput : IInput
    {
        public event Action OnShoot;
        public event Action<float, float> OnMove;
        public event Action<int> OnTakeNewWeapon;

        private int _weaponSlot = 0;
        private GameSettings _gameSettings;

        public DesktopInput(GameSettings gameSettings)
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
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");
            
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