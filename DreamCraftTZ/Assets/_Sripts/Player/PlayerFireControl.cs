using System;
using GameSystem;
using UnityEngine;

namespace WeaponControl
{
    public class PlayerFireControl : IDisposable
    {
        private readonly WeaponHandler _weaponHandler;
        private readonly BulletFabric _bulletFabric;
        private readonly GameStateUpdater _gameStateUpdater;

        private float _shootsInOneSeconds;
        private float _shootInSecond;

        public PlayerFireControl(WeaponHandler weaponHandler, BulletFabric bulletFabric, GameStateUpdater gameStateUpdater)
        {
            _weaponHandler = weaponHandler;
            _bulletFabric = bulletFabric;
            _gameStateUpdater = gameStateUpdater;
        }

        public void Initialize()
        {
            SubscribeEvents();
        }
        
        public void Dispose()
        {
            UnsubscribeEvent();
        }
        
        public void Shot()
        {
            if (!_gameStateUpdater.IsGame)
                return;
            if (!(Time.time >= _shootInSecond)) 
                return;
            _shootInSecond = Time.time + _shootsInOneSeconds;
            _bulletFabric.Shot();
        }

        private void SubscribeEvents()
        {
            _gameStateUpdater.OnGamePlayed += TakeWeapon;
            _weaponHandler.OnWeaponChanged += TakeWeapon;
        }

        private void UnsubscribeEvent()
        {
            _gameStateUpdater.OnGamePlayed -= TakeWeapon;
            _weaponHandler.OnWeaponChanged -= TakeWeapon;
        }

        private void TakeWeapon()
        {
            _weaponHandler.TakeWeapon();
            _shootsInOneSeconds = _weaponHandler.WeaponFireRate;
            _shootInSecond = _shootsInOneSeconds;
        }
    }
}