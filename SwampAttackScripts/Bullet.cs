using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _timeToDestroy = 5;
    [SerializeField] private int _demage;
    [SerializeField] private float _speed;

    private void Start()
    {
        Destroy(gameObject, _timeToDestroy);
    }
    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime, Space.Self);       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeDemage(_demage);
            Destroy(gameObject);        
        }
    }
}
