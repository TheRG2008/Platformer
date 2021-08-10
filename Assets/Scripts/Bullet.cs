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
        if (FindObjectOfType<Player>()._sprite.flipX == true)
        {
            _bulletSprite.flipX = true;
            direction = direction * -1;
        }
        else
            _bulletSprite.flipX = false;
    }

    // Update is called once per frame
    void Update()
    { 
        transform.Translate(direction * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
