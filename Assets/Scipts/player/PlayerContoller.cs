using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public float MovementSpeed = 6f;

    private Vector3 _movementVector;
    private Animator _animationController;
    private Rigidbody _rigidBody;
    private int _layerName;
    private const float CamRayLength = 100f;
   

    private void Awake()
    {
        _layerName = LayerMask.GetMask("Ground");
        _animationController = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Turning();

        if (h != 0f || v != 0f)
            _animationController.SetBool("IsWalking", true);
        else
            _animationController.SetBool("IsWalking", false);
    }

    private void Move(float h, float v)
    {
        _movementVector.Set(h, 0f, v);
        _movementVector = _movementVector.normalized * MovementSpeed * Time.deltaTime;
        _rigidBody.MovePosition(transform.position + _movementVector);
    }

    private void Turning()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitPoint;
        if (!Physics.Raycast(ray, out hitPoint, CamRayLength, _layerName)) return;
        Vector3 playerToMouse = hitPoint.point - transform.position;
        playerToMouse.y = 0f;
        _rigidBody.MoveRotation(Quaternion.LookRotation(playerToMouse));
    }
}