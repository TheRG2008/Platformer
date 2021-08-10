using System;
using UnityEngine;
using UnityEngine.UI;

    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Text _coinCountText;
        [SerializeField] private GameObject[] _iconChesst;
        [SerializeField] private GameObject[] _livesCount;
        [SerializeField] private GameObject _winPanel, _loosePanel;
        [SerializeField] private Player _player;
        [SerializeField] private GameManager _gameManager;

        private void Awake()
        {
            _player.OnChangeLifes += ShowLife;
            _player.OnPickChest += ShowChesstIcon;
            _player.OnPickCoin += () => _coinCountText.text = $"x {Scope.Value}";
        
        }

        private void ShowLife(int lifes)
        {
            switch (lifes)
            {
                case 15:
                    for (int i = 0; i < _livesCount.Length; i++)
                    {
                        _livesCount[i].gameObject.SetActive(true);
                    }
                    break;
                case 10:
                    _livesCount[2].gameObject.SetActive(false);
                    _livesCount[1].gameObject.SetActive(true);
                    break;
                case 5:
                    _livesCount[1].gameObject.SetActive(false);
                    _livesCount[2].gameObject.SetActive(false);
                    break;
                case 0:
                    for (int i = 0; i < _livesCount.Length; i++)
                    {
                        _livesCount[i].gameObject.SetActive(false);
                    }
                    break;
                default:
                    break;
            }

        }

        private void ShowChesstIcon()
        {
            _iconChesst[_gameManager.CountChest].SetActive(true);
           
        }

     
        

        public void ShowLoosePanel()
        {
            _loosePanel.gameObject.SetActive(true);
        }

        public void ShowWinPanel()
        {
            _winPanel.gameObject.SetActive(true);
        }
    }


