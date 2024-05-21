using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkipSystem : MonoBehaviour
{
    [SerializeField] private List<SkipNode> nodes;
    [SerializeField] private SkipNode startNode;

    private void Awake()
    {
        startNode.SetNode();
    }

    
}
