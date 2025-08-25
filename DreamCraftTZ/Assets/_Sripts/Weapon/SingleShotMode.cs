using UnityEngine;

namespace WeaponControl.FireModes
{
    public class SingleShotMode : IFireMode
    {
        public void Shoot(BulletFabric fabric)
        {
            fabric.SpawnBullet(fabric.DirectionDefine());
        }
    }
}