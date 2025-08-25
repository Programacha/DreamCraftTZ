using System.Collections.Generic;
using UnityEngine;
using ObjectPoolOrganizer = _Scripts.ObjectPool.ObjectPoolOrganizer;
using Random = UnityEngine.Random;

namespace _Scripts.Zombie
{
    public class ZombieFactory
    {
        private readonly ObjectPoolOrganizer _objectPoolOrganizer;
        private readonly List<GeneratedZombies> _zombiePrefabs;
        private readonly Transform _player;

        public ZombieFactory(ObjectPoolOrganizer objectPoolOrganizer, List<GeneratedZombies> zombiesPrefab, Transform player)
        {
            _objectPoolOrganizer = objectPoolOrganizer;
            _player = player;
            _zombiePrefabs = zombiesPrefab;
        }

        public void GenerateZombie(Vector2 zombiePosition)
        {
            GameObject zombie = GetZombieByChance();
            zombie.transform.position = zombiePosition;
            ZombieBehaviour zombieBehaviour = zombie.GetComponent<ZombieBehaviour>();
            zombieBehaviour.Init(_player,this);
            zombie.SetActive(true);
        }

        private GameObject GetZombieByChance()
        {
            int randomValue = Random.Range(0, _zombiePrefabs.Count);
            return GetPooledZombie(_zombiePrefabs[randomValue].ZombiesPrefab);
        }

        private GameObject GetPooledZombie(ZombieBehaviour zombie)
        {
            ObjectPool.ObjectPool objectPool = _objectPoolOrganizer.GetPool(zombie.gameObject.name);
            return objectPool.GetObject().gameObject;
        }
    }
}

