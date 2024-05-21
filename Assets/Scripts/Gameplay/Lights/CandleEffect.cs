using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleEffect : MonoBehaviour
{
    private Light _light;
    [SerializeField] private float intensityDiff;

    [Range(0f, 1f)]
    [SerializeField] private float _effectSpeed = 1;
    private float _startIntensity = 0f;

    private void Awake()
    {
        _light = GetComponent<Light>();
        _startIntensity = _light.intensity;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EffectLoop();
    }

    public void EffectLoop()
    {
        if (_light != null)
        {
            _light.intensity = _startIntensity + Mathf.PingPong(Time.time*_effectSpeed, intensityDiff);
        }
    }
}
