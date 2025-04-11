using UnityEngine;
using UnityEngine.EventSystems;

public class FuelEvent : NodeEvent
{
    private FuelEventUI _fuelEventUI;
    private FuelEventResultDto _fuelEventResultDto = new FuelEventResultDto();

    private protected override void Start()
    {
        base.Start();
        _fuelEventUI = _eventCanvasPrefab.GetComponent<FuelEventUI>();
    }

    protected override void LoadNodeEventPrefab()
    {
        _eventCanvasPrefab = Resources.Load<GameObject>("EventCanvas/FuelEventCanvas");
    }

    public override void ShowEventCanvas()
    {
        base.ShowEventCanvas();
        SettingEventCanvas();
    }

    private void SettingEventCanvas()
    {
        SetFuelAmount();
        SetDescription();
        _fuelEventUI.GetUIInfomation(_fuelEventResultDto);
    }

    private void SetFuelAmount()
    {
        // 더 복잡한 로직이 들어갈 수도 있어서 모듈화하였습니다.
        _fuelEventResultDto.fuel = Random.Range(1, 10);
    }

    private void SetDescription()
    {
        // 아래와 같이 구성할 시, 메서드 호출 순서를 지켜야합니다.
        _fuelEventResultDto.description = $"{_fuelEventResultDto.fuel}L의 연료를 얻었습니다.";
    }
}
