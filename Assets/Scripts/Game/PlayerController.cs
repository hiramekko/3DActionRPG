using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Tooltip("プレイヤーの移動速度")]
    [SerializeField] float _speed = 5.0f;
    Rigidbody _rb;
    Vector3 _dir;
    Vector3 _cameraForward;
    Vector3 _moveForward;
    float _horizontal;
    float _vertical;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
        _dir = new Vector3(_horizontal, 0, _vertical);
        _rb.velocity = _dir * _speed;
    }

    void FixedUpdate()
    {
        _cameraForward = Vector3.Scale(Camera.main.transform.forward,
            new Vector3(1, 0, 1)).normalized;
        _moveForward = _cameraForward * _vertical +
            Camera.main.transform.right * _horizontal;
        _rb.velocity = _moveForward * _speed +
            new Vector3(0, _rb.velocity.y, 0);
        if (_moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(_moveForward);
        }
    }
}
