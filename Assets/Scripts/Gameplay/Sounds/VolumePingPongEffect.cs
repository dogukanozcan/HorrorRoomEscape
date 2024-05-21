using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumePingPongEffect : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private float _volumeDiff = .1f;
  
    [Range(0f, 0.25f)]
    [SerializeField] private float _effectSpeed = 1;
    private float _startVolume;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _startVolume = _audioSource.volume;
    }

    private void Update()
    {
        EffectLoop();
    }

    public void EffectLoop()
    {
        if (_audioSource != null)
        {
            _audioSource.volume = _startVolume + Mathf.PingPong(Time.time * _effectSpeed, _volumeDiff);
        }
    }

}
