
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public Vector2 direction;
    private SpriteRenderer _bulletSprite;
    private void Awake()
    {
        _bulletSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<Player>()._sprite.flipX == true)
        {
            _bulletSprite.flipX = true;
        }
        else
            _bulletSprite.flipX = false;

        transform.Translate(direction * Time.deltaTime);
    }
}
