using UnityEngine;

namespace Dungeon
{
    public class Trap : MonoBehaviour
    {
        [SerializeField] private int Damage;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Player")) return;

            other.gameObject.GetComponent<PlayerController>().TakeDamage(Damage);
        }
    }
}
