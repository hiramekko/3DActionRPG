﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Tooltip("プレイヤーの移動速度")]
    [SerializeField] float _speed = 5.0f;
    [Tooltip("プレイヤーのジャンプ力")]
    [SerializeField] float _jumpPower = 5f;
    [Tooltip("地面との当たり判定の距離")]
    [SerializeField] float _checkGroundDistance = 0.1f;
    [Tooltip("ジャンプ回数の上限")]
    [SerializeField] int _maxJumpCount = 2;
    [Tooltip("ジャンプするボタンの名前")]
    [SerializeField] string _jumpButtonName = "Jump";
    [Tooltip("前後に移動するボタンの名前")]
    [SerializeField] string _horizontalName = "Horizontal";
    [Tooltip("左右移動するボタンの名前")]
    [SerializeField] string _verticalName = "Vertical";

    Rigidbody _rb;
    Vector3 _cameraForward;
    Vector3 _moveForward;
    float _horizontal;
    float _vertical;
    int _jumpCount = 0;
    bool _isJump = false;
    float distance = 1.0f;
    Transform _mainCam;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
        _mainCam = Camera.main.transform;

    }

    void Update()
    {
        _horizontal = Input.GetAxisRaw(_horizontalName);
        _vertical = Input.GetAxisRaw(_verticalName);
        //_dir = new Vector3(_horizontal, 0, _vertical).normalized;
        //_rb.velocity = _dir * _speed;
        //_rb.velocity = new Vector3(_rb.velocity.x, 1 * _jumpPower, _rb.velocity.z);
        Jump();
    }

    void FixedUpdate()
    {
        CameraMove();
    }

    void CameraMove()
    {
        _cameraForward = Vector3.Scale(_mainCam.forward,
                    new Vector3(1, 0, 1)).normalized;
        _moveForward = _cameraForward * _vertical +
            _mainCam.right * _horizontal;
        _rb.velocity = _moveForward * _speed +
            new Vector3(0, _rb.velocity.y, 0);

        if (_moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(_moveForward);
        }
    }

    void Jump()
    {       
        if (Input.GetButtonDown(_jumpButtonName))
        {
            _rb.AddForce(transform.up * _jumpPower, ForceMode.Impulse);
        }
    }
}

//        void CheckGround()
//        {
//            RaycastHit hit;
//#if UNITY_EDITOR
//            Debug.DrawLine(transform.position + (Vector3.up * 0.1f),
//                transform.position + (Vector3.up * 0.1f) +
//                (Vector3.down * _checkGroundDistance));
//#endif
//            if (Physics.Raycast(transform.position +
//                (Vector3.up * 0.1f), Vector3.down, out hit,
//                _checkGroundDistance))
//            {
//                _jumpCount = 0;
//            }
//        }
