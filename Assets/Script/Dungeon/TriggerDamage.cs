using UnityEngine;

namespace Dungeon
{
    public class TriggerDamage : MonoBehaviour
    {
        [SerializeField] private int Damage;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var playerController = other.gameObject.GetComponent<PlayerController>();

            if (playerController == null) return;

            playerController.TakeDamage(Damage);
        }
    }
}
