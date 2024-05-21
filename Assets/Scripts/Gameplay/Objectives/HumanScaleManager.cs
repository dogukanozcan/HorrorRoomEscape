using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HumanScaleManager : MonoBehaviour, ITriggable
{
    private const string PEEK_ANIMATION = "Peek";
    private const string HORROR_WHOSH = "HorrorShock";
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Trigger()
    {
        _animator.Play(PEEK_ANIMATION);
        SoundManager.Instance.PlayClip(HORROR_WHOSH);
    }
}