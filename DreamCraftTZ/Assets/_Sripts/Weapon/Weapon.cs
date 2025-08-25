using UnityEngine;

namespace WeaponControl
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Objects/New Weapon", order = 1)]

    public class Weapon : ScriptableObject
    {
        public Sprite WeaponSprite => _weaponSprite;
        public float ShootsInOneSecond => _shootsInOneSecond;
        public BaseBullet BaseBullet => _bullet;
        public int Damage => _damage;

        [SerializeField]private Sprite _weaponSprite;
        [SerializeField]private float _shootsInOneSecond;
        [SerializeField]private BaseBullet _bullet;
        [SerializeField]private int _damage;
    }
}