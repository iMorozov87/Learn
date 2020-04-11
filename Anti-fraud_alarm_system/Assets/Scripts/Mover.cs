using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private float _moveHorizontal;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _moveHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(_moveHorizontal * _speed * Time.deltaTime, 0, 0);
        
        if (_moveHorizontal != 0)
        {
            _animator.SetBool("Run", true);
        }
        else 
        { 
            _animator.SetBool("Run", false);
        }
        FlipChecking();
    }

    private void FlipChecking()
    {
        if ((_moveHorizontal > 0 && _spriteRenderer.flipX == true) || (_moveHorizontal < 0 && _spriteRenderer.flipX == false))
        {
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
        }
    }
}
