using System;
using UnityEngine;

public class Bullet : MonoBehaviour, IDisposable
{
    
    public Vector2 direction;
    private SpriteRenderer _bulletSprite;

    public void Dispose()
    {
        Destroy(gameObject);
    }

    private void Awake()
    {
        _bulletSprite = GetComponent<SpriteRenderer>();
        if (FindObjectOfType<Player>().Sprite.flipX == true)
        {
            _bulletSprite.flipX = true;
            direction = direction * -1;
        }
        else
            _bulletSprite.flipX = false;
    }

    
    void Update()
    { 
        transform.Translate(direction * Time.deltaTime);
        Destroy(gameObject, 3);
    }

    
}
