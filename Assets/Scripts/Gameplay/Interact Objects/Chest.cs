using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChestAnimation
{
    OpenLid,
    CloseLid
}
public class Chest : MonoBehaviour, ITriggable
{
    [SerializeField] private List<GameObject> spawnObjects = new List<GameObject>();
    [SerializeField] private Transform spawnPoint;
    private Animator _animator;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void Trigger()
    {
        OpenLid();
    }
    public void OpenLid()
    {
        SpawnObjects();
        _animator.Play(ChestAnimation.OpenLid.ToString());
    }
    public void CloseLid()
    {
        _animator.Play(ChestAnimation.CloseLid.ToString());
    }

    public void SpawnObjects()
    {
        foreach (var item in spawnObjects)
        {
            var nextGO = Instantiate(item, transform);
            nextGO.transform.position = spawnPoint.position;
            nextGO.transform.rotation = spawnPoint.rotation;
        }
    }
}
