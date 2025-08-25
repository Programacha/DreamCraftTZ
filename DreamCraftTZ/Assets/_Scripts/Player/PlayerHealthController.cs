using System;
using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerHealthController : IDisposable
    {
        private int _currentHearts;
        private readonly int _maxHearts;
        public event Action OnPlayerDeath;
        public event Action<int,int> OnHeartsChanged;
    
        private readonly PlayerBehaviour _playerBehaviour;

        public PlayerHealthController(GameSettings.GameSettings gameSettings,PlayerBehaviour playerBehaviour)
        {
            _playerBehaviour = playerBehaviour;
            _maxHearts = gameSettings.PlayerHealth;
            _currentHearts = _maxHearts;
            SubscribeEvents();
        }
    
        public void Initialization()
        {
            OnHeartsChanged?.Invoke(_currentHearts,_maxHearts);
        }

        private void SubscribeEvents()
        {
            _playerBehaviour.OnPlayerTakeDamage += TakeHit;
        }

        private void UnsubscribeEvents()
        {
            _playerBehaviour.OnPlayerTakeDamage -= TakeHit;
        }
    
        private void TakeHit(int damage)
        {
            if (_currentHearts <= 0) return;

            _currentHearts = Mathf.Max(0, _currentHearts - damage);
        
            OnHeartsChanged?.Invoke(_currentHearts, _maxHearts);

            if (_currentHearts <= 0)
            {
                OnPlayerDeath?.Invoke();
            }
        }

        public void Dispose()
        {
            UnsubscribeEvents();
        }
    }
}