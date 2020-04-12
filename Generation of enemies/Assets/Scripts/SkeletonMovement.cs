using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private SpriteRenderer _spriteRenderer;
    private Transform[] _points;
    private Vector3 _targetPosition;
    private int _currentIndex;
    private Vector3[] _targetPoint;    

    private void Start()
    {        
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _targetPoint = new Vector3[_path.childCount];
        for (int i = 0; i < _targetPoint.Length; i++)
        {
            _targetPoint[i] = _path.GetChild(i).position;
        }
    }
   
    private void Update()
    {
        _targetPosition = _targetPoint[_currentIndex];        
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition,  _speed * Time.deltaTime);
        
        FlipChecking();
        TargetChanging();
    }

    private void TargetChanging()
    {
        if (transform.position == _targetPoint[_currentIndex])
        {
            _currentIndex++;
        }
        if (_currentIndex == (_targetPoint.Length))
        {
            _currentIndex = 0;
        }
    }

    private void FlipChecking()
    {
        if (_targetPosition.x < transform.position.x && _spriteRenderer.flipX == false)
        {
            _spriteRenderer.flipX = true;
        }
        if (_targetPosition.x > transform.position.x && _spriteRenderer.flipX == true)
        {
            _spriteRenderer.flipX = false;
        }
    }
}