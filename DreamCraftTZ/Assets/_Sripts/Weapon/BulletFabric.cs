using HelpUtilities;
using ObjectPoolSystem;
using UnityEngine;
using WeaponControl.FireModes;

namespace WeaponControl
{
    public class BulletFabric
    {
        private readonly ObjectPoolOrganizer _objectPoolOrganizer;
        private readonly BaseBullet _bullet;
        private readonly WeaponHandler _weaponHandler;
        private ObjectPool _objectPool;

        public BulletFabric(ObjectPoolOrganizer objectPoolOrganizer, BaseBullet bullet, WeaponHandler weaponHandler)
        {
            _objectPoolOrganizer = objectPoolOrganizer;
            _bullet = bullet;
            _weaponHandler = weaponHandler;
        }

        public void Initialize()
        {
            _objectPool = _objectPoolOrganizer.GetPool(_bullet.gameObject.name);
        }

        public void Shot(IFireMode fireMode)
        {
            fireMode.Shoot(this);
        }

        public Vector2 DirectionDefine()
        {
            return (Utilities.GetWorldMousePosition() - _weaponHandler.Weapon.transform.position).normalized;
        }

        public void SpawnBullet(Vector2 direction)
        {
            GameObject bulletObject = _objectPool.GetObject().gameObject;
            if (bulletObject == null) return;

            bulletObject.SetActive(true);
            BaseBullet baseBullet = bulletObject.GetComponent<BaseBullet>();
            baseBullet.StartMoveBullet(_weaponHandler.Weapon.transform.position, direction, _weaponHandler.BulletDamage);
        }
    }
}