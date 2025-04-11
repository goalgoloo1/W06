using UnityEngine;

public abstract class NodeEvent : MonoBehaviour
{
    protected GameObject _eventCanvasPrefab;

    protected virtual private void Start()
    {
        // ������ UIManager���� �����ؾ��ϴ� �κ��Դϴ�.
        // ������ ���� �ٵ� ��� �������� �ϴ��� UI�� ������ ��ũ��Ʈ�� �� �� ����?
        // �׷��� ���߿� �ѹ��� UIManager �����丵 �ǽ��ϰ��� �մϴ�.
        LoadNodeEventPrefab();
    }

    protected virtual void LoadNodeEventPrefab()
    {
        //_eventCanvasPrefab = Resources.Load<GameObject>("Event/EventCanvas");
    }

    public virtual void ShowEventCanvas()
    {
        Instantiate(_eventCanvasPrefab);
    }
}
