using System.Collections.Generic;
using _Scripts.Weapon;
using _Scripts.Zombie;
using UnityEngine;
using ObjectPoolOrganizer = _Scripts.ObjectPool.ObjectPoolOrganizer;

namespace _Scripts.GameSettings
{
    [CreateAssetMenu(fileName = "Game Settings", menuName = "Scriptable Objects/New Game Settings", order = 1)]

    public class GameSettings : ScriptableObject
    {
        [Header("Object Pool Settings")]

        public List<ObjectPoolOrganizer.PoolConfig> PoolConfigs;

        [Space(10)]

        [Header("Player Settings")]

        public BaseBullet BaseBulletPrefab;
        public Weapon.Weapon[] Weapon;
        public float WeaponDistanceFromPlayer;
        public float PlayerMoveSpeed;
        public int PlayerHealth;

        [Space(10)]

        [Header("Zombie Spawn Parameters")]
        
        public float BaseTimeToSpawnNewZombie;

        public List<GeneratedZombies> ZombiePrefabs;
    }
}