using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    private const string CLICK_SOUND = "Click02";
    private MeshRenderer _plateRenderer;
    private readonly Color closeColor = Color.red;
    private readonly Color openColor = Color.green;
    private bool currentStatus = false;

    public event Action<bool> OnPressed;
    public event Action OnReset;
    private void Awake()
    {
        _plateRenderer = GetComponent<MeshRenderer>();
        ChangeStatus(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SwitchStatus();
            OnPressed?.Invoke(currentStatus);
            SoundManager.Instance.PlayClip3D(CLICK_SOUND, transform.position);
        }
    }
    private IEnumerator ResetTrigger()
    {
        yield return new WaitForSeconds(RoomProperties.Instance.pressurePlateCD);
        OnReset?.Invoke();
        SoundManager.Instance.PlayClip3D(CLICK_SOUND, transform.position);
        ChangeStatus(false);
    }
    public void SwitchStatus()
    {
        ChangeStatus(!currentStatus);
    }
    public void ChangeStatus(bool status)
    {
        currentStatus = status;
        if (status)
        {
            StartCoroutine(ResetTrigger());
            ChangePlateColor(openColor);
        }
        else
        {
            StopAllCoroutines();
            ChangePlateColor(closeColor);
        }
    }
    
    private void ChangePlateColor(Color color)
    {
        var mat = _plateRenderer.material;
        mat.color = color;
        _plateRenderer.material = mat;
    }
}
