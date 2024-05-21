using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotManager : MonoBehaviour
{
    private Light _light;
    private ParticleSystem _particleSystem;
    [SerializeField] private PressurePlate _trigger;
    public bool IsLightOn { get { return _light.enabled; } }

    private void OnEnable()
    {
        if (!_trigger) return;
        _trigger.OnPressed += OnTriggered;
        _trigger.OnReset += OnResetTrigger;
    }
    private void OnDisable()
    {
        if (!_trigger) return;
        _trigger.OnPressed -= OnTriggered;
        _trigger.OnReset -= OnResetTrigger;
    }

    private void Awake() 
    {
        _light = GetComponentInChildren<Light>(true);
        _particleSystem = GetComponentInChildren<ParticleSystem>(true);
    } 
    private void OnResetTrigger() => CloseLight();
    private void OnTriggered(bool status) => ChangeStatus(status);
    public void ChangeStatus(bool status)
    {
        if (status) { OpenLight(); } else { CloseLight(); }
    }

    public void OpenLight() 
    {
        _particleSystem.gameObject.SetActive(true);
        _light.enabled = true; 
    }
    public void CloseLight()
    {
        _particleSystem.gameObject.SetActive(false);
        _light.enabled = false;
    }
}
