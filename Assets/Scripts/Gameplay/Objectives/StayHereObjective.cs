using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayHereObjective : MonoBehaviour, ICompletable
{
    private PressurePlate[] _plates;
    private int _plateCount = 0;
    private bool _objectiveCompleted = false;
    [SerializeField] private GameObject triggableObject;


    private void OnEnable()
    {
        foreach (var trigger in _plates)
        {
            trigger.OnPressed += OnPressed;
            trigger.OnReset += OnReset;
        }
    }
    private void OnDisable()
    {
        foreach (var trigger in _plates)
        {
            trigger.OnPressed -= OnPressed;
            trigger.OnReset -= OnReset;
        }
    }
    private void Awake()
    {
        _plates = GetComponentsInChildren<PressurePlate>();
    }

    public void OnPressed(bool status)
    {
        if (status)
        {
            _plateCount++;

            if (_plateCount >= _plates.Length)
            {
                OnObjectiveComplete();
            }
        }
        else
        {
            _plateCount--;
        }
      
    }

    public void OnReset()
    {
        _plateCount--;
    }

    public void OnObjectiveComplete()
    {
        if (_objectiveCompleted) return;
        Complete();

        ITriggable triggable = triggableObject.GetComponent<ITriggable>();
        if (triggable != null)
        {
            triggable.Trigger();
        }
        else
        {
            Debug.LogError("StayHereObjective: " + triggableObject.name + " is not a Triggable");
        }
        
    }

    public void Complete()
    {
        _objectiveCompleted = true;
    }
}
