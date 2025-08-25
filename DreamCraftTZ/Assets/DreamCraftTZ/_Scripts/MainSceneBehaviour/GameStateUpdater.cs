using System;
using _Scripts.Player;
using UnityEngine;

namespace _Scripts.MainSceneBehaviour
{
    public class GameStateUpdater : MonoBehaviour, IDisposable

    {
        public event Action OnGamePlayed;
        public event Action OnGameEnded;

        private PlayerHealthController _playerHealthController;

        private SceneController _sceneController;

        public bool IsGame { get; private set; }

        public void Initialize(SceneController sceneController, PlayerHealthController playerHealthController)
        {
            IsGame = false;
            _playerHealthController = playerHealthController;
            _sceneController = sceneController;
            SubscribeEvents();
        }
        
        public void Dispose()
        {
            UnsubscribeEvents();
        }

        public void StartGame()
        {
            IsGame = true;
            OnGamePlayed?.Invoke();
        }

        public void RestartGame()
        {
            _sceneController.ReloadGameScene();
        }

        private void SubscribeEvents()
        {
            _playerHealthController.OnPlayerDeath += GameOver;
        }

        private void UnsubscribeEvents()
        {
            _playerHealthController.OnPlayerDeath -= GameOver;
        }

        private void GameOver()
        {
            IsGame = false;
            OnGameEnded?.Invoke();
        }
    }
}