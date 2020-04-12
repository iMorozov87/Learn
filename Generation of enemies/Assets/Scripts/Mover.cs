using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{    
    [SerializeField] float _speed;
    
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;    

    private void Start()
    {
        _animator =GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        transform.Translate(moveHorizontal * _speed*Time.deltaTime, moveVertical * _speed*Time.deltaTime, 0);
        FlipChecking(moveHorizontal);
     
        if(moveHorizontal!=0 ||moveVertical!=0)
        {
            _animator.SetBool("Run", true);
        }
        else
        {
            _animator.SetBool("Run", false);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {            
            _animator.SetTrigger("Attack");
            DestroyEnemy();
        }
    }

    private void FlipChecking(float moveHorizontal)
    {
        if (moveHorizontal < 0 && _spriteRenderer.flipX == false)
        {
            _spriteRenderer.flipX = true;
        }
        else if (moveHorizontal > 0 && _spriteRenderer.flipX == true)
        {
            _spriteRenderer.flipX = false;
        }
    }

    private void DestroyEnemy()
    {
        float radiusHit = 0.9F;
        var possibleEnemies = Physics2D.OverlapCircleAll(transform.position, radiusHit);
        foreach (var possibleEnemy in possibleEnemies)
        {
            if (possibleEnemy.gameObject.TryGetComponent<Enemy>(out Enemy newEnemy))
            {
                Destroy(newEnemy.gameObject);
            }
        }
    }
}
