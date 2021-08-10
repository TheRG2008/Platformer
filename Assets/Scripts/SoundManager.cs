using System;
using UnityEngine;




    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private GameObject _pickCoin, _endGame, _background, _pickKey, _pickChest, _damage, _pickLifes, _showChest;
        private void _Play (AudioSource source, bool loop)
        {
            source.loop = loop;
            source.Play();
        }
        public void Stop(Sound sound)
        {
            switch (sound)
            {
                case Sound.PickCoin:
                    _pickCoin.GetComponent<AudioSource>().Stop();
                    break;
                case Sound.EndGame:
                    _endGame.GetComponent<AudioSource>().Stop();
                    break;
                case Sound.Background:
                    _background.GetComponent<AudioSource>().Stop();
                    break;
                case Sound.PickKey:
                    _pickKey.GetComponent<AudioSource>().Stop();
                    break;
                case Sound.PickChest:
                    _pickChest.GetComponent<AudioSource>().Stop();
                    break;
                case Sound.Damage:
                    _damage.GetComponent<AudioSource>().Stop();
                    break;
                case Sound.PickLifes:
                    _pickLifes.GetComponent<AudioSource>().Stop();
                    break;
                case Sound.ShowChest:
                    _showChest.GetComponent<AudioSource>().Stop();
                    break;
              
            }
        }

        public void Play(Sound sound, bool loop = false)
        {
            
            switch (sound)
            {
                case Sound.PickCoin:
                    _Play(_pickCoin.GetComponent<AudioSource>(), loop);
                    break;
                case Sound.EndGame:
                    _Play(_endGame.GetComponent<AudioSource>(), loop);
                    break;
                case Sound.Background:
                    _Play(_background.GetComponent<AudioSource>(), loop);
                    break;
                case Sound.PickKey:
                    _Play(_pickKey.GetComponent<AudioSource>(), loop);
                    break;
                case Sound.PickChest:
                    _Play(_pickChest.GetComponent<AudioSource>(), loop);
                    break;
                case Sound.Damage:
                    _Play(_damage.GetComponent<AudioSource>(), loop);
                    break;
                case Sound.PickLifes:
                    _Play(_pickLifes.GetComponent<AudioSource>(), loop);
                    break;
                case Sound.ShowChest:
                    _Play(_showChest.GetComponent<AudioSource>(), loop);
                    break;
              
            }
        }
    }
    public enum Sound
    {
        PickCoin,
        EndGame,
        Background,
        PickKey,
        PickChest,
        Damage,
        PickLifes,
        ShowChest
    }

