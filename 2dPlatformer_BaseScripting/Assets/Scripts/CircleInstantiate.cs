using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleInstantiate : MonoBehaviour
{
    [SerializeField] private int _countGem;
    [SerializeField] private float _radius;
    [SerializeField] private Gem _gemTemplate;

    private void Start()
    {
        float angelStep = 360 / _countGem;
        for (int i = 0; i < _countGem; i++)
        {
            Gem newGem = Instantiate(_gemTemplate, new Vector3(0, 0, 0), Quaternion.identity);
            newGem.transform.position = new Vector3(_radius * Mathf.Cos(angelStep * (i+1) * Mathf.Deg2Rad)+
                transform.position.x, _radius * Mathf.Sin(angelStep * (i+1) * Mathf.Deg2Rad) + transform.position.y, 0);
        }       
    }
}
