using System;
using _Scripts.Player;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI
{
    public class PlayerHealthView : MonoBehaviour, IDisposable
    {
        [SerializeField] private Image[] _heartImages;

        private PlayerHealthController _playerHealthController;

        public void Initialize(PlayerHealthController playerHealthController)
        {
            _playerHealthController = playerHealthController;
            SubscribeEvents();
        }
    
        public void Dispose()
        {
            UnsubscribeEvents();
        }

        private void SubscribeEvents()
        {
            _playerHealthController.OnHeartsChanged += UpdateHearts;
        }

        private void UnsubscribeEvents()
        {
            _playerHealthController.OnHeartsChanged -= UpdateHearts;
        }

        private void UpdateHearts(int current, int max)
        {
            for (int i = 0; i < _heartImages.Length; i++)
            {
                bool filled = i < current;
            
                _heartImages[i].gameObject.SetActive(filled);
            }
        }
    }
}