using UnityEngine;

namespace Camera
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] private Transform Target;

        [SerializeField] private float SmoothTime;

        private bool _isSmooth;

        private Vector3 _velocity = Vector3.zero;

        private void Start()
        {
            if (SmoothTime > 0) _isSmooth = true;

            SetPosition(false);
        }

        void Update()
        {
            SetPosition(_isSmooth);
        }

        public void SetPosition(bool isSmooth)
        {
            Vector3 followPosition = Target.position;

            if (isSmooth)
            {
                Vector3 targetPosition = new Vector3(followPosition.x, followPosition.y, -10f);
                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, SmoothTime);
            }
            else
            {
                transform.position = new Vector3(followPosition.x, followPosition.y, -10f);
            }
        }
    }
}
