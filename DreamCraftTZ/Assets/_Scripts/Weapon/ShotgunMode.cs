using UnityEngine;

namespace _Scripts.Weapon
{
    public class ShotgunMode : IFireMode
    {
        private readonly int _pellets;
        private readonly float _spreadAngle;

        public ShotgunMode(int pellets = 3, float spreadAngle = 15f)
        {
            _pellets = pellets;
            _spreadAngle = spreadAngle;
        }

        public void Shoot(BulletFabric fabric)
        {
            Vector2 baseDir = fabric.DirectionDefine();
            float halfSpread = (_pellets - 1) * _spreadAngle * 0.5f;

            for (int i = 0; i < _pellets; i++)
            {
                float angle = -halfSpread + i * _spreadAngle;
                Vector2 dir = Quaternion.Euler(0, 0, angle) * baseDir;
                fabric.SpawnBullet(dir);
            }
        }
    }
}