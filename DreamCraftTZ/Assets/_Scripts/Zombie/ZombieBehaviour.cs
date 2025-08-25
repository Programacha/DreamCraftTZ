using _Scripts.ObjectPool;
using UnityEngine;

namespace _Scripts.Zombie
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PooledObject))]

    public class ZombieBehaviour : MonoBehaviour
    {
        public int Damage => _damage;
        
        [Header("Zombie Stats")]

        [SerializeField]
        protected float _speed;
        [SerializeField]
        protected int _healPoint;
        [SerializeField]
        protected Sprite _zombieSprite;
        [SerializeField]
        protected int _damage;

        protected Transform _player;
        private SpriteRenderer _sprite;
        private PooledObject _pooledObject;
        private ZombieFactory _zombieFactory;
        
        protected bool _isInit;
        private int _currentHealPoint;

        protected virtual void Awake()
        {
            _pooledObject = GetComponent<PooledObject>();
            _sprite = gameObject.GetComponent<SpriteRenderer>();
        }

        public virtual void Init(Transform player, ZombieFactory zombieFactory)
        {
            _zombieFactory = zombieFactory;
            _currentHealPoint = _healPoint;
            _player = player;
            _isInit = true;
            _sprite.sprite = _zombieSprite;
        }

        public virtual void TakeDamage(int damage)
        {
            _currentHealPoint -= damage;
            if (_currentHealPoint > 0)
                return;
            DeactivateObject();
        }

        private void DeactivateObject()
        {
            _pooledObject.ReturnToPool();
            gameObject.SetActive(false);
        }
        
    }
}


