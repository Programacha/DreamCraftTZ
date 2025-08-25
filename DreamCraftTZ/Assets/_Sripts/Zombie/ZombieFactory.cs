using System.Collections.Generic;
using UnityEngine;
using ObjectPoolSystem;
using System;
using Random = UnityEngine.Random;

namespace ZombieGeneratorBehaviour
{
    public class ZombieFactory
    {
        public event Action <ZombieBehaviour> OnZombieSpawned;
        public event Action <ZombieBehaviour> OnZombieDestroyed;

        private readonly ObjectPoolOrganizer _objectPoolOrganizer;
        private readonly List<GeneratedZombies> _zombiePrefabs;
        private readonly Transform _player;
        private List<ZombieBehaviour> _generatedActiveZombies;

        public ZombieFactory(ObjectPoolOrganizer objectPoolOrganizer, List<GeneratedZombies> zombiesPrefab, Transform player)
        {
            _objectPoolOrganizer = objectPoolOrganizer;
            _player = player;
            _zombiePrefabs = zombiesPrefab;
        }
        
        public void Initialize()
        {
            _generatedActiveZombies = new List<ZombieBehaviour>();
        }
        
        public void GenerateZombie(Vector2 zombiePosition)
        {
            GameObject zombie = GetZombieByChance();
            zombie.transform.position = zombiePosition;
            ZombieBehaviour zombieBehaviour = zombie.GetComponent<ZombieBehaviour>();
            zombieBehaviour.Init(_player,this);
            _generatedActiveZombies.Add(zombieBehaviour);
            zombie.SetActive(true);
            OnZombieSpawned?.Invoke(zombieBehaviour);
        }

        public void DeleteFromZombieList(ZombieBehaviour zombieBehaviour)
        {
            OnZombieDestroyed?.Invoke(zombieBehaviour);
            _generatedActiveZombies.Remove(zombieBehaviour);
        }
        
        private void DeactivateAllZombies()
        {
            List<ZombieBehaviour> generatedZombies = new List<ZombieBehaviour>(_generatedActiveZombies);
            
            foreach (var zombieBehaviour in generatedZombies)
            {
                zombieBehaviour.DeactivateObject();
            }
        }

        private GameObject GetZombieByChance()
        {
            int randomValue = Random.Range(0, _zombiePrefabs.Count);
            return GetPooledZombie(_zombiePrefabs[randomValue].ZombiesPrefab);
        }

        private GameObject GetPooledZombie(ZombieBehaviour zombie)
        {
            ObjectPool objectPool = _objectPoolOrganizer.GetPool(zombie.gameObject.name);
            return objectPool.GetObject().gameObject;
        }
    }
}

