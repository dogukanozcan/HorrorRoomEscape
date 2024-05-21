using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGate : MonoBehaviour, ITriggable
{
    private const string OPEN_WALL = "OpenWall";
    private const string SECRET_DOOR = "SecretDoor";
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Open()
    {
        print("openwall");
        _animator?.Play(OPEN_WALL);
        SoundManager.Instance.PlayClip3D(SECRET_DOOR, transform.position);
    }

    public void Trigger()
    {
        Open();
    }
}
