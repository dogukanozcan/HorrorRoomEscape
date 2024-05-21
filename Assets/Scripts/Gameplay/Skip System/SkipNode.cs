using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkipNode : MonoBehaviour
{
    [SerializeField] private bool active;

    [SerializeField] private List<GameObject> deactiveObjects = new List<GameObject>();
    [SerializeField] private List<Transform> completables = new();
    public void SetNode()
    {
        active = true;
        SetPositionAndRotation();
        DeactivateObject();
        CompleteCompletables();
    }

    public void SetPositionAndRotation()
    {
        PlayerManager.Instance.transform.position = transform.position;
        PlayerManager.Instance.transform.rotation = transform.rotation;
    }

    public void DeactivateObject()
    {
        foreach (GameObject obj in deactiveObjects)
        {
            obj.SetActive(false);
        }
    }

    public void CompleteCompletables()
    {
        foreach (var item in completables)
        {
            item.GetComponent<ICompletable>().Complete();
        }
    }
}
