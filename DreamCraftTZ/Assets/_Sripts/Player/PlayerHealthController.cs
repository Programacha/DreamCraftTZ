// PlayerHealth.cs
using System;
using _Sripts.Player;
using GameSystem;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthController : IDisposable
{
    public int CurrentHearts { get; private set; }
    private readonly int _maxHearts;
    
    
    public event Action OnPlayerDeath;
    public event Action<int,int> OnHeartsChanged;
    
    private readonly PlayerBehaviour _playerBehaviour;

    public PlayerHealthController(GameSettings gameSettings,PlayerBehaviour playerBehaviour)
    {
        _playerBehaviour = playerBehaviour;
        _maxHearts = gameSettings.PlayerHealth;
        CurrentHearts = _maxHearts;
        SubscribeEvents();
    }
    
    public void Initialization()
    {
        OnHeartsChanged?.Invoke(CurrentHearts,_maxHearts);
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
        if (CurrentHearts <= 0) return;

        CurrentHearts = Mathf.Max(0, CurrentHearts - damage);
        
        OnHeartsChanged?.Invoke(CurrentHearts, _maxHearts);

        if (CurrentHearts <= 0)
        {
            OnPlayerDeath?.Invoke();
        }
    }

    public void Dispose()
    {
        UnsubscribeEvents();
    }
}