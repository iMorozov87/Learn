using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageEnemy : MonoBehaviour
{
    [SerializeField]private GameObject _player;    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player> (out Player player))
        {            
            Destroy(_player);
        }
    }
}
