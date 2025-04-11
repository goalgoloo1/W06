using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 패싸움 로직을 만들어 보겠습니다.
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

    // 이벤트에 연결될 메서드
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
        // 랜덤으로 생성된 percentage 값보다 evilRaate가 높으면 싸움에 참여합니다.
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
        // 아래와 같이 구성할 시, 메서드 호출 순서를 지켜야합니다.
        if (_fightEventResultDto.fightedCrewKeys.Count < 2)
        {
            _fightEventResultDto.description = "아무도 싸우지 않았습니다.";
        }
        else
        {
            for (int i = 0; i < _fightEventResultDto.fightedCrewKeys.Count; i++)
            {
                if (i == _fightEventResultDto.fightedCrewKeys.Count - 1)
                {
                    _fightEventResultDto.description += $"{GameManager.Data.crewData[_fightEventResultDto.fightedCrewKeys[i]].Name}가 싸웠습니다.";
                }
                else
                {
                    _fightEventResultDto.description += $"{GameManager.Data.crewData[_fightEventResultDto.fightedCrewKeys[i]].Name}, ";
                }
            }
        }
    }
}
