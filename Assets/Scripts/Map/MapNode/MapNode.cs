using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class MapNode : MonoBehaviour
{
    [SerializeField] int _nodeId;
    [SerializeField] List<MapNode> _connectedNodes = new List<MapNode>();
    [SerializeField] Button _nodeButton;

    bool _isVisited;

    public void SetInteractable(bool interactable)
    {
        _nodeButton.interactable = interactable;
    }

}
