using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    private float _axisConstantZ = -10f;   
    
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position,new Vector3 (_target.position.x, _target.position.y, _axisConstantZ) ,  _speed*Time.deltaTime);        
    }
}
