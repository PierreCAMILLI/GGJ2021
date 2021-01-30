using UnityEngine;

namespace HUD
{
    public class LifeCheck : MonoBehaviour
    {
        [SerializeField] private int LifeAmount;

        public void Execute(int currentLife)
        {
            gameObject.SetActive(currentLife >= LifeAmount);
        }
    }
}
