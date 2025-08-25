using UnityEngine;

namespace _Scripts.ObjectPool
{
    public class PooledObject : MonoBehaviour
    {
        public ObjectPool Pool { get; set; }

        public void ReturnToPool()
        {
            Pool.ReturnToPool(this);
        }
    }

}