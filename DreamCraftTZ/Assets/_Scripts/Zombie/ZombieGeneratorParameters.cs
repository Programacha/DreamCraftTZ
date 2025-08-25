using _Scripts.MainSceneBehaviour;
using UnityEngine;

namespace _Scripts.Zombie
{
    public class ZombieGeneratorParameters
    {
        private readonly ZombieFactory _zombieFabric;
        private readonly GameStateUpdater _gameStateUpdater;
        
        private float _baseTimeToSpawnNewZombie;
        private float _newTimeToNextSpawn;
        private float _timeToNewSpawn;

        private bool _isMinimalValueReached;

        public ZombieGeneratorParameters
        (GameStateUpdater gameStateUpdater,
            float baseTimeToSpawnNewZombie,
            ZombieFactory zombieFabric)
        {
            _gameStateUpdater = gameStateUpdater;
            _baseTimeToSpawnNewZombie = baseTimeToSpawnNewZombie;
            _zombieFabric = zombieFabric;
        }
        
        public void Initialize()
        {
            _newTimeToNextSpawn = _baseTimeToSpawnNewZombie;
        }

        public void Tick()
        {
            if (_gameStateUpdater.IsGame)
            {
                _baseTimeToSpawnNewZombie -= Time.deltaTime;
                
                if (_baseTimeToSpawnNewZombie <= 0)
                {
                    _baseTimeToSpawnNewZombie = _newTimeToNextSpawn;
                    _zombieFabric.GenerateZombie(Utilities.Utilities.GetInvisiblePoint());
                }
            }
        }
    }
}
