using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[System.Serializable]
public class DepthOfFieldValues
{
    public float focusDistance;
    [Range(1,300)] public float focalLength;
}
public class PPManager : MonoSingleton<PPManager>
{
    [SerializeField] private DepthOfFieldValues _detailView_DepthOfFieldValues;
     private DepthOfFieldValues _default_DepthOfFieldValues;

    private Volume _volume;
    private DepthOfField _depthOfField;

    private void Awake()
    {
        _volume = GetComponent<Volume>();

        _volume.profile.TryGet(out _depthOfField);
        _default_DepthOfFieldValues = GetDepthOfFieldValues();
    }
    public void SetDetailViewMode(float distance)
    {
        ChangeDepthOfFieldValues(_detailView_DepthOfFieldValues, distance);
    }
    public void SetDefaultMode()
    {
        ChangeDepthOfFieldValues(_default_DepthOfFieldValues);
    }
    #region DoF
    public void ChangeDepthOfFieldValues(DepthOfFieldValues values, float distance = -1)
    {
        _depthOfField.focalLength.value = (values.focalLength);
        if(distance == -1)
        {
            _depthOfField.focusDistance.value = (values.focusDistance);
        }
        else
        {
            _depthOfField.focusDistance.value = distance;
        }
        
    }
    public DepthOfFieldValues GetDepthOfFieldValues()
    {
        var values = new DepthOfFieldValues();
        values.focalLength = _depthOfField.focalLength.value;
        values.focusDistance = _depthOfField.focusDistance.value;
        return values;
    }

    #endregion
}
