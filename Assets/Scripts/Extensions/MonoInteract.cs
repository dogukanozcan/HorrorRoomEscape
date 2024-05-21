using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof(QuickOutline))] 
public abstract class MonoInteract : MonoBehaviour
{
    public QuickOutline _outline;
    internal bool _highlighted;
    public bool CanInteract = true;

    public virtual void Awake()
    {
        _outline = GetComponent<QuickOutline>();
        _outline.enabled = false;

    }
    public virtual void OnHighlight()
    {
        if (_highlighted) { return; }

        _highlighted = true;
        _outline.enabled = true;
    }  
    public virtual void OnHighlightEnd()
    {
        _highlighted = false;
        _outline.enabled = false;
    }

    public abstract string GetText();
    public abstract void Interact();
}
