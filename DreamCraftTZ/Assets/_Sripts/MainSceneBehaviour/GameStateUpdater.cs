using System;
using _Sripts.Player;
using UnityEngine;

namespace GameSystem
{
    public class GameStateUpdater : MonoBehaviour
    {
        public event Action OnGamePlayed;
        public event Action OnGameEnded;
        
        [SerializeField] private PlayerBehaviour _player;
        
        private SceneController _sceneController;

        public bool IsGame { get; private set; }

        public void Initialize(SceneController sceneController)
        {
            IsGame = false;
            _sceneController = sceneController;
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

        private void OnEnable()
        {
            _player.OnPlayerDeath += GameOver;
        }

        private void OnDisable()
        {
            _player.OnPlayerDeath -= GameOver;
        }
        
        private void GameOver()
        {
            IsGame = false;
            OnGameEnded?.Invoke();
        }
    }
}