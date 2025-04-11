using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �нο� ������ ����� ���ڽ��ϴ�.
/// </summary>
public class FightEvent : NodeEvent
{
    private FightEventUI _fightEventUI;
    private FightEventResultDto _fightEventResultDto = new FightEventResultDto();

    private protected override void Start()
    {
        base.Start();
        _fightEventUI = _eventCanvasPrefab.GetComponent<FightEventUI>();
    }

    // �̺�Ʈ�� ����� �޼���
    public override void ShowEventCanvas()
    {
        SettingEventCanvas();
        base.ShowEventCanvas();
    }

    protected override void LoadNodeEventPrefab()
    {
        _eventCanvasPrefab = Resources.Load<GameObject>("EventCanvas/FightEventCanvas");
    }

    private void SettingEventCanvas()
    {
        SetFightCrews();
        SetDamage();
        SetDescription();
        _fightEventUI.GetUIInfomation(_fightEventResultDto);
    }

    private void SetFightCrews()
    {
        // �������� ������ percentage ������ evilRaate�� ������ �ο� �����մϴ�.
        float percentage = Random.Range(0f, 100f);
        List<string> crewListTruck = GameManager.CrewManager.CrewListTruck;
        foreach (string crewKey in crewListTruck)
        {
            if(percentage < GameManager.Data.crewData[crewKey].EvilRate)
            {
                _fightEventResultDto.fightedCrewKeys.Add(crewKey);
            }
        }
    }

    private void SetDamage()
    {
        _fightEventResultDto.damage = Random.Range(20, 50);
    }

    private void SetDescription()
    {
        // �Ʒ��� ���� ������ ��, �޼��� ȣ�� ������ ���Ѿ��մϴ�.
        if (_fightEventResultDto.fightedCrewKeys.Count < 2)
        {
            _fightEventResultDto.description = "�ƹ��� �ο��� �ʾҽ��ϴ�.";
        }
        else
        {
            for (int i = 0; i < _fightEventResultDto.fightedCrewKeys.Count; i++)
            {
                if (i == _fightEventResultDto.fightedCrewKeys.Count - 1)
                {
                    _fightEventResultDto.description += $"{GameManager.Data.crewData[_fightEventResultDto.fightedCrewKeys[i]].Name}�� �ο����ϴ�.";
                }
                else
                {
                    _fightEventResultDto.description += $"{GameManager.Data.crewData[_fightEventResultDto.fightedCrewKeys[i]].Name}, ";
                }
            }
        }
    }
}
