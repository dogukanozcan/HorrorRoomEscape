// Script by Marcelli Michele

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class MoveRuller : MonoBehaviour
{
    public bool IsActive = false;
    public UnityEvent OnPasswordCorrect;

    [HideInInspector] public DetailView DetailView;
    [HideInInspector] public List <PadLockEmissionColor> Rullers = new List<PadLockEmissionColor>();
    [HideInInspector] public int[] NumberArray = {0,0,0,0};

    private int _scroolRuller = 0;
    private int _changeRuller = 0;
    private int _numberRuller = 0;
    private PadLockPassword _lockPassword;

    void Awake()
    {
        _lockPassword = GetComponent<PadLockPassword>();
        Rullers = GetComponentsInChildren<PadLockEmissionColor>().ToList();
      
        foreach (var r in Rullers)
        {
            r.transform.Rotate(-144, 0, 0, Space.Self);
        }

        DetailView = GetComponent<DetailView>();
        DetailView.OnDetailViewStart += () => IsActive = true;
        DetailView.OnDetailViewEnd += () => DeactiveRuller();
    }
    void Update()
    {
        if (!IsActive) return;

        MoveRulles();
        RotateRullers();
        _lockPassword.Password();
    }

    void MoveRulles()
    {
        if (Input.GetKeyDown(KeyCode.D)) 
        {
            _changeRuller ++;
            _numberRuller += 1;

            if (_numberRuller > 3)
            {
                _numberRuller = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            _changeRuller --;
            _numberRuller -= 1;

            if (_numberRuller < 0)
            {
                _numberRuller = 3;
            }
        }
        _changeRuller = (_changeRuller + Rullers.Count) % Rullers.Count;


        for (int i = 0; i < Rullers.Count; i++)
        {
            if (IsActive)
            {
                if (_changeRuller == i)
                {

                    Rullers[i].IsSelected = true;
                    Rullers[i].BlinkingMaterial();
                }
                else
                {
                    Rullers[i].IsSelected = false;
                    Rullers[i].BlinkingMaterial();
                }
            }
        }

    }

    void RotateRullers()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {  
            _scroolRuller = 36;
            Rullers[_changeRuller].transform.Rotate(-_scroolRuller, 0, 0, Space.Self);

            NumberArray[_changeRuller] += 1;

            if (NumberArray[_changeRuller] > 9)
            {
                NumberArray[_changeRuller] = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            _scroolRuller = 36;
            Rullers[_changeRuller].transform.Rotate(_scroolRuller, 0, 0, Space.Self);

            NumberArray[_changeRuller] -= 1;

            if (NumberArray[_changeRuller] < 0)
            {
                NumberArray[_changeRuller] = 9;
            }
        }
    }

    public void DeactiveRuller()
    {
        IsActive = false;
        for (int i = 0; i < Rullers.Count; i++)
        {
            Rullers[i].IsSelected = false;
            Rullers[i].BlinkingMaterial();
        }
    }

    public void PasswordCorrect()
    {
        DetailView.CanInteract = false;
        DetailView.EndDetailView();
        OnPasswordCorrect?.Invoke();
    }
}
