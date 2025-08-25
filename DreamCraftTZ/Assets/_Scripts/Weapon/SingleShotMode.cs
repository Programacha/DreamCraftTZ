namespace _Scripts.Weapon
{
    public class SingleShotMode : IFireMode
    {
        public void Shoot(BulletFabric fabric)
        {
            fabric.SpawnBullet(fabric.DirectionDefine());
        }
    }
}