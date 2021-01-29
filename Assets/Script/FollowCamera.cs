using UnityEngine;
using UnityEngine.Serialization;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private GameObject Target;

    [SerializeField] private Vector3 Velocity = Vector3.zero;

    [SerializeField] private float SmoothTime;

    private float _depth;


    // Start is called before the first frame update
    void Start()
    {
        _depth = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 followPosition = Target.transform.position;
        Vector3 targetPosition = new Vector3(followPosition.x, followPosition.y, _depth);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref Velocity, SmoothTime);
    }
}
