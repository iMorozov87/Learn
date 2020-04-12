using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    private Transform[] _spownPoits;

    private void Start()
    {
        _spownPoits = new Transform[gameObject.transform.childCount];
        for (int i = 0; i < _spownPoits.Length; i++)
        {
            _spownPoits[i] = gameObject.transform.GetChild(i);
        }
        StartCoroutine(Spown());
    }

    private IEnumerator Spown()
    {        
        int currentPoint = 0;
        while (true)
        {
            Instantiate(_enemy, _spownPoits[currentPoint].position, Quaternion.identity);            
            yield return new WaitForSeconds(2);
            currentPoint++;
            if (currentPoint == _spownPoits.Length)
            {
                currentPoint = 0;
            }
        }        
    }
}
