using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GemSpawn : MonoBehaviour
{
    [SerializeField] private Gem _gemTemplate;

    private void Start()
    {
        int maxNumberGemX = 5;
        int maxNumberGemY = 3;
        Vector3 _currentPosition = transform.position;

        for (int j = 0; j < maxNumberGemY; j++)
        {
            for (int i = 0; i < maxNumberGemX; i++)
            {
                Instantiate(_gemTemplate, _currentPosition, Quaternion.identity);
                _currentPosition.x++;
            }
            _currentPosition.x = transform.position.x;
            _currentPosition.y++;
        }
    }
}


