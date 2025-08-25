using GameSystem;
using UnityEngine;
using UnityEngine.UI;

namespace _Sripts.UI
{
    public class GameButtonsView : MonoBehaviour
    {
        [SerializeField] 
        private Button _playButton;
        [SerializeField] 
        private Button _restartButton;
        [SerializeField]
        private GameStateUpdater _gameStateUpdater;

        private void Awake()
        {
            SubscribeEvents();
            UnsubscribeEvents();
            AddListenersForButtons();
        }

        private void OffStartGameButton()
        {
            _playButton.gameObject.SetActive(false);
        }
        
        private void OnRestartGameButton()
        {
            _restartButton.gameObject.SetActive(true);
        }

        private void SubscribeEvents()
        {
            _gameStateUpdater.OnGamePlayed += OffStartGameButton;
            _gameStateUpdater.OnGameEnded += OnRestartGameButton;
        }
        
        private void UnsubscribeEvents()
        {
            _gameStateUpdater.OnGamePlayed += OffStartGameButton;
            _gameStateUpdater.OnGameEnded += OnRestartGameButton;
        }
        
        private void AddListenersForButtons()
        {
            _playButton.onClick.AddListener(_gameStateUpdater.StartGame);
            _restartButton.onClick.AddListener(_gameStateUpdater.RestartGame);
        }
    }
}