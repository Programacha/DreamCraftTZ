using GameSystem;
using UnityEngine;
using _Sripts.InputHandler;
using ObjectPoolSystem;
using WeaponControl;
using ZombieGeneratorBehaviour;

namespace _Sripts
{
    public class Startup : MonoBehaviour
    {
        [SerializeField] private GameSettings _gameSettings;
        [SerializeField] private Transform _player;
        [SerializeField] private SpriteRenderer _weaponSpriteRenderer;
        [SerializeField]private GameStateUpdater _gameStateUpdater;
        
        private DesktopInput _desktopInput;
        private PlayerMovementController _playerMovementController;
        private InputController _inputController;
        private PlayerFireControl _playerFireControl;
        private WeaponHandler _weaponHandler;
        private BulletFabric _bulletFabric;
        private ObjectPoolOrganizer _objectPoolOrganizer;
        private ZombieFactory _zombieFactory;
        private ZombieGeneratorParameters _zombieGeneratorParameters;
        private SceneController _sceneController;

        private void Awake()
        {
            CreateInstancies();
        }

        private void Start()
        {
            Initializing();
        }

        private void CreateInstancies()
        {
            _sceneController = new SceneController();
            
            _objectPoolOrganizer = new ObjectPoolOrganizer(_gameSettings.PoolConfigs);
            
            _desktopInput = new DesktopInput(_gameSettings);
           
            _playerMovementController = new PlayerMovementController
                (_player,
                    _gameSettings.PlayerMoveSpeed);
            
            _weaponHandler = new WeaponHandler
            (
                    _player,
                    _gameSettings.WeaponDistanceFromPlayer,
                    _gameSettings,
                    _weaponSpriteRenderer);
           
            _bulletFabric = new BulletFabric
                (_objectPoolOrganizer,
                    _gameSettings.BaseBulletPrefab,
                    _weaponHandler);
           
            _playerFireControl = new PlayerFireControl
                (_weaponHandler,
                    _bulletFabric,
                    _gameStateUpdater);
            
            _inputController = new InputController
                (_playerMovementController,
                    _desktopInput,
                    _playerFireControl,
                    _weaponHandler);
            
            _zombieFactory = new ZombieFactory
                (_objectPoolOrganizer,
                    _gameSettings.ZombiePrefabs,
                    _player);
            
            _zombieGeneratorParameters = new ZombieGeneratorParameters
            (_gameStateUpdater,
                _gameSettings.BaseTimeToSpawnNewZombie,
                _zombieFactory);
        }

        private void Initializing()
        {
            _gameStateUpdater.Initialize(_sceneController);
            _inputController.Initialize();
            _objectPoolOrganizer.Initialize();
            _bulletFabric.Initialize();
            _playerFireControl.Initialize();
            _zombieFactory.Initialize();
            _zombieGeneratorParameters.Initialize();
            _weaponHandler.Initialization();
        }

        private void Update()
        {
            CallTick();
        }

        private void CallTick()
        {
            _desktopInput.Tick();
            _weaponHandler.Tick();
            _zombieGeneratorParameters.Tick();
        }
    }
}
