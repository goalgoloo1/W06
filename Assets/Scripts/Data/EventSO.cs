using UnityEngine;

[CreateAssetMenu(fileName = "EventSO", menuName = "Scriptable Objects/EventSO")]
public class EventSO : ScriptableObject
{
    [SerializeField] private int _eventId;
    [SerializeField] private EventType _eventType;
}
