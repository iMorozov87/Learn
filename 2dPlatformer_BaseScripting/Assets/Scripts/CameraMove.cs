using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private float _speed;

    private Vector3 _targetPosition;    
    private int _verticalCoefficient = 5;
    private void Update()
    {
        if (_target != null)
        {
            _targetPosition = new Vector3(_target.transform.position.x, _target.transform.position.y + _verticalCoefficient, -10);
            transform.position = Vector3.Lerp(transform.position, _targetPosition, _speed * Time.deltaTime);
        }        
    }
}
