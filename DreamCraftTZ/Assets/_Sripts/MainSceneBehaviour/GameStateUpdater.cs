using System;
using _Sripts.Player;
using UnityEngine;

namespace GameSystem
{
    public class GameStateUpdater : MonoBehaviour
    {
        public event Action OnGamePlayed;
        public event Action OnGameEnded;
        
        [SerializeField] private PlayerHealthController _playerHealthController;
        
        private SceneController _sceneController;

        public bool IsGame { get; private set; }

        public void Initialize(SceneController sceneController,PlayerHealthController playerHealthController)
        {
            IsGame = false;
            _playerHealthController = playerHealthController;
            _sceneController = sceneController;
            SubscribeEvents();
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