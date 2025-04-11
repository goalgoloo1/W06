using UnityEngine;

public class HireEvent : NodeEvent
{
    private HireEventUI _hireEventUI;
    private HireEventResultDto _hireEventResultDto = new HireEventResultDto();

    private protected override void Start()
    {
        base.Start();
        _hireEventUI = _eventCanvasPrefab.GetComponent<HireEventUI>();
    }

    protected override void LoadNodeEventPrefab()
    {
        _eventCanvasPrefab = Resources.Load<GameObject>("EventCanvas/HireEventCanvas");
    }

    public override void ShowEventCanvas()
    {
        base.ShowEventCanvas();
        SettingEventCanvas();
    }

    private void SettingEventCanvas()
    {
        SetHireCrew();
        SetDescription();
        _hireEventUI.GetUIInfomation(_hireEventResultDto);
    }

    private void SetHireCrew()
    {
        // �� ������ ������ �� ���� �־ ���ȭ�Ͽ����ϴ�.
        _hireEventResultDto.crew = GameManager.CrewManager.ShowCrew();
    }

    private void SetDescription()
    {
        // �Ʒ��� ���� ������ ��, �޼��� ȣ�� ������ ���Ѿ��մϴ�.
        _hireEventResultDto.description = $"{_hireEventResultDto.crew.Name}�� �շ��ϰ� �;��մϴ�.";
    }

}
