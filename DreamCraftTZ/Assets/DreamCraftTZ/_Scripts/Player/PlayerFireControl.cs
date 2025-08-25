using System;
using _Scripts.MainSceneBehaviour;
using _Scripts.Weapon;
using UnityEngine;

namespace _Scripts.Player
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
            
            IFireMode fireMode = _weaponHandler.WeaponFireMode switch
            {
                FireModeType.Single => new SingleShotMode(),
                FireModeType.Shotgun => new ShotgunMode(3, 10f),
                _ => new SingleShotMode()
            };

            _bulletFabric.Shot(fireMode);
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