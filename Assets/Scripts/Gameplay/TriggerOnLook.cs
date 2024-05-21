using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerOnLook : MonoBehaviour
{
    [SerializeField] private Transform _viewPoint;
    [SerializeField] private GameObject _triggable;
    private bool _triggered = false;
    private void Update()
    {
        if (_triggered) return;
        if (FieldOfView.Instance.CheckPosInFOV(_viewPoint.position))
        {
            _triggered = true;
            _triggable.GetComponent<ITriggable>().Trigger();

        }
    }

}
