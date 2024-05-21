using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class DetailView : MonoInteract
{
    public Action OnDetailViewStart;
    public Action OnDetailViewEnd;

    [SerializeField] private Vector3 _displayRotation;
    [SerializeField] private float _displayScale = 1;
    [SerializeField] private float _displayDistance = .5f;
  
    private bool _onDetailView;
    private Vector3 _lastMousePosition;
    private Vector3 _viewPoint;

    private Vector3 _defaultPosition;
    private Quaternion _defaultRotation;

    public override void Awake()
    {
        base.Awake();
    }
    private void Update()
    {
        if (_onDetailView)
        {
            OnDetailView();
        }
    }
    public override void Interact()
    {
        if (!CanInteract) return;

        if(_onDetailView ) 
        {
            EndDetailView();
        }
        else
        {
            StartDetailView();
        }
        
    }

    public override string GetText()
    {
        return "Look";
    }
    #region Highlight
    public override void OnHighlight()
    {
        if (!CanInteract) return;
        if (_highlighted || _onDetailView) { return; }
     
        _highlighted = true;
        _outline.enabled = true;
    }

    #endregion

    public void StartDetailView()
    {
        OnHighlightEnd();

        _onDetailView = true;
        _defaultPosition = transform.position;
        _defaultRotation = transform.rotation;

        transform.LookAt(Camera.main.transform);
        transform.Rotate(_displayRotation);
        transform.localScale *= _displayScale;

        OnDetailViewStart?.Invoke();
        _viewPoint = Camera.main.transform.position + Camera.main.transform.forward* _displayDistance;
        _lastMousePosition = Input.mousePosition;
        CursorState.SetCursorState(false);
        CursorState.OverrideLock(true);
        LockPlayer();

        //pp
        PPManager.Instance.SetDetailViewMode(_displayDistance);

        //flashlight
        FlashlightManager.Instance.CanEnable = false;
    }
    public void OnDetailView()
    {
        //UPDATE LOOP
        transform.position = Vector3.Lerp(transform.position, _viewPoint, 0.2f);
       
        if (false)
        {
            Vector3 deltaMouse = Input.mousePosition - _lastMousePosition;
            float rotationSpeed = .10f;
            transform.Rotate(deltaMouse.x * rotationSpeed * Vector3.right, Space.World);
            transform.Rotate(deltaMouse.y * rotationSpeed * Vector3.up, Space.World);
        }
        _lastMousePosition = Input.mousePosition;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EndDetailView();
        }

    }
    public void EndDetailView()
    {
        _onDetailView = false;

        transform.position = _defaultPosition;
        transform.rotation = _defaultRotation;
        transform.localScale /= _displayScale;

        OnDetailViewEnd?.Invoke();
        CursorState.OverrideLock(false);
        CursorState.SetCursorState(true);
        UnlockPlayer();

        OnHighlight();

        //pp
        PPManager.Instance.SetDefaultMode();

        //flashlight
        FlashlightManager.Instance.CanEnable = true;
    }

    public void LockPlayer()
    {
        var controller = PlayerManager.Instance.GetComponent<FirstPersonController>();
        controller.CanMove = false;
        controller.CanLook = false;
    }

    public void UnlockPlayer()
    {
        var controller = PlayerManager.Instance.GetComponent<FirstPersonController>();
        controller.CanMove = true;
        controller.CanLook = true;
    }
}
