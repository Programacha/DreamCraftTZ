using System;
using _Scripts.Zombie;
using UnityEngine;

namespace _Scripts.Player
{
    [RequireComponent(typeof(BoxCollider2D))]

    public class PlayerBehaviour : MonoBehaviour
    {
        public event Action<int> OnPlayerTakeDamage;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<ZombieBehaviour>(out ZombieBehaviour zombie))
            {
                OnPlayerTakeDamage?.Invoke(zombie.Damage);
            }
        }
    }

}