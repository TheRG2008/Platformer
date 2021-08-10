
using UnityEngine;

public class GameManager : MonoBehaviour
{    
    [SerializeField] private GameObject _coinSpawn;
    [SerializeField] private GameObject _enemySpawn;
    [SerializeField] private GameObject _chesst, _key, _gun;
    [SerializeField] private Transform _chesstSpawnPoint, _keySpwnPoint, _gunSpawnPoint;
    [SerializeField] private Player _player;
    [SerializeField] private SoundManager _soundManager;
    [SerializeField] private UIManager _uiManager;

    private int _countChest;
    public int CountChest 
    { 
        get => _countChest;
        private set 
        {
            _countChest = value;
            if (_countChest >= 3)
                Win();

            RecalculetedSpawnRate();
        } 
    }

    private void Awake()
    {
        _player.OnPickChest += () => CountChest++;
        _player.OnDie += Loose;
        Scope.ChangeValue += ShowChest;
        Scope.ChangeValue += ShowGun;
    }
    private void ShowChest (int coinCount)
    {
        //if (coinCount == 10 || coinCount == 50 || coinCount == 100)
        //{
        //    _ShowChest();
        //}
        if (coinCount != 2 && coinCount != 50 && coinCount != 100)
            return;
        _ShowChest();

    }
    private void _ShowChest()
    {
        _soundManager.Play(Sound.ShowChest);
        Instantiate(_chesst, _chesstSpawnPoint.gameObject.transform);
        Instantiate(_key, _keySpwnPoint.gameObject.transform);        
    }

    private void ShowGun(int coinCounter)
    {
        if (coinCounter == 20)
            _ShowGun();
    }

    private void _ShowGun()
    {
        _soundManager.Play(Sound.ShowChest);
        Instantiate(_gun, _gunSpawnPoint.gameObject.transform);
    }

    private void Loose()
    {
        Invoke("DelayLoosePanel", 2);
    }
    private void DelayLoosePanel()
    {
        _uiManager.ShowLoosePanel();
    }

    private void Win()
    {
        _uiManager.ShowWinPanel();
    }

    private void RecalculetedSpawnRate ()
    {
        switch (_countChest)
        {
            case 1:
               
                _coinSpawn.GetComponent<CoinSpawn>()._spawnRate = 1;
                _enemySpawn.GetComponent<Factory>()._spawnRate = 0.5f;
                break;
            case 2:                
                _coinSpawn.GetComponent<CoinSpawn>()._spawnRate = 0.5f;
                _enemySpawn.GetComponent<Factory>()._spawnRate = 0.2f;
                break;
            case 3:
                Win();                
                break;

        }
    }




}
