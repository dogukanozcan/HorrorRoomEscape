using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractPresenter : MonoSingleton<InteractPresenter>
{
    [SerializeField] private Image _crosshairBorderImage;
    [SerializeField] private Image _crosshairImage;
    private void OnEnable()
    {
        InteractManager.Instance.OnHighlight += OnHighlight;
        InteractManager.Instance.OnHighlightEnd += OnHighlightEnd;
    }
    public void OnHighlight(MonoInteract interactable)
    {
        _crosshairBorderImage.color = Color.blue;
    }
    public void OnHighlightEnd()
    {
        _crosshairBorderImage.color = Color.white;
    }
}
