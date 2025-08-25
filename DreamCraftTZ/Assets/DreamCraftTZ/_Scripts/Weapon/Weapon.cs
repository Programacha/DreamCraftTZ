using UnityEngine;

namespace _Scripts.Weapon
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Objects/New Weapon", order = 1)]

    public class Weapon : ScriptableObject
    {
        public Sprite WeaponSprite => _weaponSprite;
        public float ShootsInOneSecond => _shootsInOneSecond;
        public int Damage => _damage;
        public FireModeType FireMode => _fireModeType;

        [SerializeField] private FireModeType _fireModeType;
        [SerializeField]private Sprite _weaponSprite;
        [SerializeField]private float _shootsInOneSecond;
        [SerializeField]private BaseBullet _bullet;
        [SerializeField]private int _damage;
    }
}