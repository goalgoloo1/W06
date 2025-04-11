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
        // 더 복잡한 로직이 들어갈 수도 있어서 모듈화하였습니다.
        _hireEventResultDto.crew = GameManager.CrewManager.ShowCrew();
    }

    private void SetDescription()
    {
        // 아래와 같이 구성할 시, 메서드 호출 순서를 지켜야합니다.
        _hireEventResultDto.description = $"{_hireEventResultDto.crew.Name}가 합류하고 싶어합니다.";
    }

}
