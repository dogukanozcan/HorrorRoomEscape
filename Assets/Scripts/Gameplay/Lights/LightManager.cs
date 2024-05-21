using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
  
    private MeshRenderer meshRenderer;
    private Light _light;
    private float _startIntensity;
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        _light = GetComponentInChildren<Light>();
        _startIntensity = _light.intensity;
        _light.intensity = 0;
    }
    public void TurnOn()
    {
        _light.enabled = true;
    }


    private void Update()
    {
        var threshold = RoomProperties.Instance.lightTurnOnDistance;
        if (DistanceToPlayer() < threshold)
        {
            meshRenderer.material.EnableKeyword("_EMISSION");
            _light.intensity = Mathf.Lerp(_startIntensity, 0, DistanceToPlayer()/ threshold);
        }
        else
        {
            meshRenderer.material.DisableKeyword("_EMISSION");
            _light.intensity = 0;
        }
    }

    public float DistanceToPlayer()
    {
        return Vector3.Distance(transform.position, PlayerManager.Instance.transform.position);
    }
}
