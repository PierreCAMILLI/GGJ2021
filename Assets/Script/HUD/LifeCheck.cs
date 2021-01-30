using UnityEngine;

namespace HUD
{
    public class LifeCheck : MonoBehaviour
    {
        [SerializeField] private int LifeAmount;

        public void Update()
        {
            gameObject.SetActive(PlayerInfos.Instance.Life >= LifeAmount);
        }
    }
}
