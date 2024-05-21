using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightManager : MonoSingleton<FlashlightManager>
{
    public bool CanEnable 
    {
        get 
        {
            return _canEnable;
        }
        set
        {
            _canEnable = value;
            if(!_canEnable)
            {
                TurnOFF();
            }
        }
    }
    private bool _canEnable;

    private const string CLICK_SOUND = "Click02";
    private Light[] _light;
    private bool IsFlashlightON { get => _light[0].enabled; }
    private bool active = false;
    private void Awake()
    {
        _light = GetComponentsInChildren<Light>();
        TurnOFF();
        SetActive();    
    }

    public void TurnON()
    {
        foreach (var item in _light)
        {
            item.enabled = true;
        }
       
    }

    private void TurnOFF()
    {
        foreach (var item in _light)
        {
            item.enabled = false;
        }
    }
    
    private void Switch()
    {
        SoundManager.Instance.PlayClip(CLICK_SOUND);
        if (IsFlashlightON)
        {
            TurnOFF();
        }
        else
        {
            TurnON();
        }
    }

    public void SetActive()
    {
        active = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!active)
                return;
             
            Switch();
        }
    }
}
