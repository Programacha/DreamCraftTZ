using System;

namespace _Scripts.InputHandler
{
    public interface IInput
    {
        public event Action OnShoot;
        public event Action<float,float> OnMove;
        public event Action<int> OnTakeNewWeapon;

        public void TakeShoot();
        public void TakeMovement();
        public void TakeNewWeapon();
    }
}