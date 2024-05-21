using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TreeDemonAnimation
{
    Appear,
    Attack,
    Grab,
    ThumbsUp,
    Angry,
}
public class TreeDemonManager : MonoBehaviour, ITriggable
{
    private const string TREEDEMON_SPAWNSOUND = "HorrorShockMid";
    [SerializeField] private Transform _treeDemonStayPoint;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void Trigger()
    {
        gameObject.SetActive(true);
        transform.DOMove(_treeDemonStayPoint.position, 1f);
        SoundManager.Instance.PlayClip3D(name: TREEDEMON_SPAWNSOUND,transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
