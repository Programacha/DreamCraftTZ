using System.Collections.Generic;
using UnityEngine;
using ZombieGeneratorBehaviour;
using WeaponControl;
using ObjectPoolSystem;

namespace GameSystem
{
    [CreateAssetMenu(fileName = "Game Settings", menuName = "Scriptable Objects/New Game Settings", order = 1)]

    public class GameSettings : ScriptableObject
    {
        [Header("Object Pool Settings")]

        public List<ObjectPoolOrganizer.PoolConfig> PoolConfigs;

        [Space(10)]

        [Header("Player Settings")]

        public BaseBullet BaseBulletPrefab;
        public Weapon[] Weapon;
        public float WeaponDistanceFromPlayer;
        public float PlayerMoveSpeed;
        public int PlayerHealth;

        [Space(10)]

        [Header("Zombie Spawn Parameters")]
        
        public float BaseTimeToSpawnNewZombie;

        public List<GeneratedZombies> ZombiePrefabs;
    }
}