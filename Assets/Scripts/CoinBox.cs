
using UnityEngine;

public class CoinBox : MonoBehaviour
{
    [SerializeField] private SoundManager _soundManager;
    [SerializeField] private GameObject coin;
    [SerializeField] private Transform coinBoxRespavn;
    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    public void GetCoinInBox()
    {
        Instantiate(coin, coinBoxRespavn.gameObject.transform);
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _anim.SetBool("boxUp", true);
            Scope.Value++;
            _soundManager.Play(Sound.PickCoin);
        }
       
    }

    public void StopAnimation () 
    {
        _anim.SetBool("boxUp", false);
    }
}
