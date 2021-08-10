
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private Player _player;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            _player.lifes = 0;
            
        }
    }
}
