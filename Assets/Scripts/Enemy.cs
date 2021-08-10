using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{        
    private int _enemyObject;
    private int _groundObject;
    private Animator _anim;
    private Rigidbody2D _rb2d;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _rb2d = GetComponent<Rigidbody2D>();
        _enemyObject = LayerMask.NameToLayer("Enemy");
        _groundObject = LayerMask.NameToLayer("Ground");
    }
    

    private void Update()
    {
        Physics2D.IgnoreLayerCollision(_enemyObject, _groundObject, true);
    }

  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" )
        {           
            _rb2d.simulated = false;
            _anim.SetBool("explosion", true);
            FindObjectOfType<SoundManager>().Play(Sound.Damage);
            Invoke("DestroyBarel", 0.5f);
        }
        else
        {
            Destroy(gameObject);

        }
    }

    private void DestroyBarel()
    {
        
        FindObjectOfType<Player>().lifes -= 5;
        Destroy(gameObject);
    }
}
