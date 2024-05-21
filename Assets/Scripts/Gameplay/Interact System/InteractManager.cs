using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractManager : MonoSingleton<InteractManager>
{
    public MonoInteract Interactable;
    public Action<MonoInteract> OnHighlight;
    public Action OnHighlightEnd;

    [SerializeField] private LayerMask _interactLayer;
    [SerializeField] private float _maxDistance = 4f;
    
    private Camera _camera;
    

    private void Awake()
    {
        _camera = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        var ray = new Ray(_camera.transform.position, _camera.transform.forward);
        var raycast = Physics.Raycast(ray, out RaycastHit hit, maxDistance: _maxDistance, layerMask: _interactLayer);
        if (raycast && TryFindComponent<MonoInteract>(hit.collider.transform, out var interactable))
        {
            if(Interactable == null || Interactable != interactable)
            {
                interactable?.OnHighlight();
                OnHighlight?.Invoke(interactable);
                Interactable = interactable;
            }
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactable?.Interact();
            }
        }
        else
        {
            if (Interactable != null) 
            {
                Interactable?.OnHighlightEnd();
                OnHighlightEnd?.Invoke();
                Interactable = null;
            }
        }
    }

    public bool TryFindComponent<T>(Transform getTransform, out T component)
    {
        if (getTransform.TryGetComponent(out component))
        {
            return true;
        }
        else
        {
            component = getTransform.GetComponentInParent<T>();
            if(component != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    private void OnDisable()
    {
        OnHighlight = null;
        OnHighlightEnd = null;
    }
}
