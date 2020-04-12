using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]

public class Signalising : MonoBehaviour
{
    [SerializeField] float _deltaVolume;

    private AudioSource _audioSource;
    private bool _soundPlay = false;
    private Coroutine _coroutine;
    private int _targetVolume;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_soundPlay == true)
        {
            StopCoroutine(_coroutine);
        }
        _audioSource.Play();
        _targetVolume = 1;
        _coroutine = StartCoroutine(SmoothVolumeChange(_deltaVolume));
        _soundPlay = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_soundPlay == true)
        {
            StopCoroutine(_coroutine);
        }
        _targetVolume = 0;
        _coroutine = StartCoroutine(SmoothVolumeChange(_deltaVolume *-1));
        _soundPlay = true;
    }

     private IEnumerator SmoothVolumeChange(float deltaVolume)
     {       
            while (_audioSource.volume != _targetVolume)
            {
                _audioSource.volume += deltaVolume*Time.deltaTime;

            yield return null;
            }
            _soundPlay = false;
     }
}