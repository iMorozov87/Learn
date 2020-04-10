using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovements : MonoBehaviour
{    
    [SerializeField] private float _speed;
    [SerializeField] private int _JumpForce;
    [SerializeField] private Transform _pointSupport;
    [SerializeField] private LayerMask _ground;

    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private bool _directionRight = true;
    private bool _isGrounded;    
    private float _chekRadius = 0.5f;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(1, true);            
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move(-1, false);
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            _animator.SetFloat("Speed", 0);
        }
    }
    private void Jump()
    {
        _isGrounded = Physics2D.OverlapCircle(_pointSupport.position, _chekRadius, _ground);
        if (_isGrounded)
        {
            _animator.SetTrigger("Jump");
            _rigidbody2D.AddForce(Vector2.up * _JumpForce);
        }        
    }
    private void Move(int directionCoefficient, bool controlDirection)
    {
        transform.Translate(_speed *directionCoefficient* Time.deltaTime, 0, 0);
        _animator.SetFloat("Speed", 1);
        if (_directionRight !=controlDirection)
        {
            Flip();
        }
    }
    private void Flip()
    {
        _directionRight = !_directionRight;
        Vector2 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
}
