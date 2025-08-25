using System;
using GameSystem;
using HelpUtilities;
using UnityEngine;

namespace WeaponControl
{
    public class WeaponHandler
    {
        public Action OnWeaponChanged;
        
        private Weapon _currentWeapon;
        private readonly Transform _player;
        private readonly float _weaponDistanceFromPlayer;
        private readonly GameSettings _gameSettings;

        public SpriteRenderer Weapon { get;}

        public int BulletDamage
        {
            get
            {
                if (_currentWeapon == null)
                    return 0;
                return _currentWeapon.Damage;
            }
        }

        public float WeaponFireRate
        {
            get
            {
                if (_currentWeapon == null)
                    return 0;
                return _currentWeapon.ShootsInOneSecond;
            }
        }

        public WeaponHandler(Transform player, float weaponDistanceFromPlayer,GameSettings gameSettings,SpriteRenderer weapon)
        {
            Weapon = weapon;
            _gameSettings = gameSettings;
            _player = player;
            _weaponDistanceFromPlayer = weaponDistanceFromPlayer;
        }

        public void Initialization()
        {
            SetUpNewWeapon(0);
        }

        public void Tick()
        {
            RotateWeaponTowardsMouse();
        }

        public void TakeWeapon()
        {
            Weapon.sprite = _currentWeapon?.WeaponSprite;
        }

        public void SetUpNewWeapon(int weaponSlot)
        {
            if (weaponSlot < _gameSettings.Weapon.Length)
            {
                _currentWeapon = _gameSettings.Weapon[weaponSlot];
                OnWeaponChanged?.Invoke();
            }
        }

        private void RotateWeaponTowardsMouse()
        {
            Weapon.transform.position = _player.position + GetDirectionPlayerToMouse() * _weaponDistanceFromPlayer;
            float angle = Mathf.Atan2(GetDirectionPlayerToMouse().y, GetDirectionPlayerToMouse().x) * Mathf.Rad2Deg;
            Weapon.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }

        private Vector3 GetDirectionPlayerToMouse()
        {
            return (Utilities.GetWorldMousePosition() - _player.position).normalized;
        }
    }
}