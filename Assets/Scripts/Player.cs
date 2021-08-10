using System;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _jumpForse = 15f;
    [SerializeField] private Transform groundChek;
    [SerializeField] private LayerMask ground;
    [SerializeField] private SoundManager _soundManager;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private bool isGun = false;

    private Rigidbody2D _rb;
    public SpriteRenderer _sprite;
    private Animator _anim;
    private int _playerObject;
    private int _groundObject;
    private int _lifes = 15;
    
    private bool isGrounded;
    private float checkRadius = 0.5f;
    private bool _isKey = false;
    

    public int lifes
    {
        get => _lifes;
        set
        {
            _lifes = value;
            if (_lifes <= 0)
            {
                Die();
                _lifes = 0;
                OnDie?.Invoke();
            }
            _lifes = _lifes > 15 ? 15 : _lifes;
            OnChangeLifes?.Invoke(_lifes);
               
        }
    }
    public event Action OnPickChest;
    public event Action<int> OnChangeLifes;
    public event Action OnDie;
    public event Action OnPickCoin;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }
    private void Start()
    {
        _playerObject = LayerMask.NameToLayer("Player");
        _groundObject = LayerMask.NameToLayer("Ground");
        
       
    }
    private void Update()
    {
        Move();
        IgnorLayer();
        CheckingGround(); 
    }
    
    private void Move()
    {
        if (Input.GetButton("Horizontal"))
        {
            _anim.SetBool("run", true);
            Run();
        }
        else
        {
            _anim.SetBool("run", false);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            _anim.SetBool("jump", true);
            Jump();
        }
        else
        {
            _anim.SetBool("jump", false);
        }
        if (Input.GetButtonDown("Fire1") && isGun == true) 
        {
            Fire();
        }
    }

    private void Fire()
    {
        Instantiate(_bullet, _shootPoint.transform.position, Quaternion.identity);
    }

    private void IgnorLayer ()
    {
        if (_rb.velocity.y > 0)
        {
            Physics2D.IgnoreLayerCollision(_playerObject, _groundObject, true);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(_playerObject, _groundObject, false);
        }
    }
    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, _speed * Time.deltaTime);
        _sprite.flipX = dir.x < 0.0f;
    }
    private void Jump()
    {
        _rb.AddForce(transform.up * _jumpForse, ForceMode2D.Impulse);
    }
    private void CheckingGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundChek.position, checkRadius, ground);

    }
    private void Die()
    {
        _soundManager.Stop(Sound.Background);
        _soundManager.Play(Sound.EndGame);
        _anim.SetBool("die", true);
        Invoke("ShowLoosePanel", 2);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            _soundManager.Play(Sound.PickCoin);
            Scope.Value++;
            OnPickCoin?.Invoke();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Life"))
        {
            _soundManager.Play(Sound.PickLifes);
            lifes+= 5;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Key"))
        {
            _soundManager.Play(Sound.PickKey);
            _isKey = true;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Gun"))
        {
            _soundManager.Play(Sound.PickLifes);
            isGun = true;
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Chest" && _isKey == true)
        {
            _soundManager.Play(Sound.PickChest);            
            _isKey = false;
            Destroy(other.gameObject);            
            OnPickChest?.Invoke();

        }
    }

   
}
