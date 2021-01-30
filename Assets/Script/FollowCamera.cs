using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform Target;

    [SerializeField] private float SmoothTime;

    private Vector3 _velocity = Vector3.zero;

    void Update()
    {
        Vector3 followPosition = Target.position;
        Vector3 targetPosition = new Vector3(followPosition.x, followPosition.y, -10f);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, SmoothTime);
    }
}
