using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoInteract
{
    enum DoorAnimation
    {
        open,
        close
    }
    [SerializeField] private ItemData _key;
    private Animator _animator;
    private bool isLocked = true;
  
    public override void Awake()
    {
        base.Awake();
        _animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    public override void Interact()
    {
        OpenDoor();
    }

    public void OpenDoor()
    {
        if (isLocked)
        {
            if(!CheckKeyExist())
            {
                print("Door is locked!");
            }
            else
            {
                Unlock();
                OpenDoor();
            }
            return;
        }

        _animator.SetTrigger(DoorAnimation.open.ToString());
    }

    public void CloseDoor()
    {
        _animator.SetTrigger(DoorAnimation.close.ToString());
    }

    public void Unlock()
    {
        isLocked = false;
    }
    public void Lock()
    {
        isLocked = true;
    }

    public bool CheckKeyExist()
    {
        return InventoryManager.Instance.inventory.Find(item => item == _key) != null;
    }

    public override string GetText() => "Door";
}
