using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 _offset;
    public float Smoothing = 5f;
    public Transform Target;

    private void Start()
    {
        _offset = transform.position - Target.position;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position + _offset, Smoothing * Time.deltaTime);
    }
}