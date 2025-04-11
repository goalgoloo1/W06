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
        // �� ������ ������ �� ���� �־ ���ȭ�Ͽ����ϴ�.
        _fuelEventResultDto.fuel = Random.Range(1, 10);
    }

    private void SetDescription()
    {
        // �Ʒ��� ���� ������ ��, �޼��� ȣ�� ������ ���Ѿ��մϴ�.
        _fuelEventResultDto.description = $"{_fuelEventResultDto.fuel}L�� ���Ḧ ������ϴ�.";
    }
}
